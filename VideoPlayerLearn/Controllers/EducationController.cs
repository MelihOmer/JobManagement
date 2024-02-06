using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Models;
namespace VideoPlayerLearn.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IDepartmentService _departmentService;
        private readonly IEducationCategoryService _educationCategoryService;
        private readonly IHttpContextAccessor _httpContext;

        public EducationController(IEducationService educationService, IDepartmentService departmentService, IEducationCategoryService educationCategoryService, IHttpContextAccessor httpContext)
        {
            _educationService = educationService;
            _departmentService = departmentService;
            _educationCategoryService = educationCategoryService;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            var eduList = _educationService.EducationListWithInclude();
            return View(eduList);
        }
        public async Task<IActionResult> GetEducationsByCategoryAsync(int Id)
        {
            var eduList = _educationService.EducationListWithInclude().Where(x => x.EduEducationCategoryId == Id).ToList();
            var cateName = await _educationCategoryService.GetById(Id);
            ViewBag.CategoryName = cateName.Title;

                return View(eduList);

        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            EducationCreateModel model = new()
            {
                Departments = new SelectList(_departmentService.DepartmentList(), "Id", "Decription"),
                EducationCategories = new SelectList(await _educationCategoryService.GetAllAsync(), "Id", "Title"),
                Education = new Education()
                {
                    AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId(),
                    CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
                }
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EducationCreateModel model)
        {
            var createdId = await _educationService.EducationCreate(model.Education);
            if (model.Image != null)
            {
                await _educationService.EducationImageSave(model.Image, createdId);
            }
            if (model.Video != null)
            {
                await _educationService.EducationVideoSave(model.Video, createdId);
            }
            return RedirectToAction("Index", "Education");
        }
        public async Task<IActionResult> EducationListAsync(int currentPage = 1, int pageSize = 8, bool isAscending = false)
        {
            
            var dto = await _educationService.GetAllByPagingAsync(currentPage, pageSize, isAscending);

            var categoryList = await _educationCategoryService.GetAllAsync();
            List<EducationWithCategoryListModel> list = new();
            for (int i = 0; i < categoryList.Count; i++)
            {
                list.Add(new()
                {
                    Id = categoryList[i].Id,
                    Description = categoryList[i].Title,
                    IsChecked = false
                });
            }


            EducationListVM model = new EducationListVM()
            {
                Educations = dto.Educations,
                CategoryList = list,
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscending,
                TotalCount = dto.TotalCount,
                TotalPages = dto.TotalPages
            };
            return View(model);
        }
        public IActionResult EducationFilterList(EducationListVM vModel)
        {
            var eduList = _educationService.GetAllQueryable()
                .Include(x => x.AppUser)
                .Include(x => x.Department)
                .Include(x => x.EducationCategory)
                .ToList();
            List<Education> resultView = new();
            for (int i = 0; i < vModel.CategoryList.Count; i++)
            {
                if (vModel.CategoryList[i].IsChecked)
                {
                    resultView.AddRange(eduList.Where(x => x.EduEducationCategoryId.ToString().Contains(vModel.CategoryList[i].Id.ToString())).ToList());
                }
            }
            if (!string.IsNullOrWhiteSpace(vModel.TitleFilter))
            {
                resultView = resultView.Where(x => x.Title.ToUpper().Contains(vModel.TitleFilter.ToUpper())).ToList();
            }
            return View(new EducationListVM
            {
                Educations = resultView,
                CategoryList = vModel.CategoryList
            });
        }
        public IActionResult EducationDetails(int Id)
        {
           var data =  _educationService.GetEducationById(Id);
            return View(data);
        }


    }
}
