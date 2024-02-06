using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IDepartmentService _departmentService;
        private readonly ITodoStatusService _todoStatusService;
        public readonly IMapper _mapper;
        private readonly ITodoService _todoService;


        public HomeController(IUow uow, IHttpContextAccessor httpContext, IDepartmentService departmentService, ITodoStatusService todoStatusService, IMapper mapper, ITodoService todoService)
        {
            _uow = uow;
            _httpContext = httpContext;
            _departmentService = departmentService;
            _todoStatusService = todoStatusService;
            _mapper = mapper;
            _todoService = todoService;
        }


        public IActionResult Index(int departmentId)
        {
            if (departmentId == 0)
                departmentId = _httpContext.HttpContext.User.GetLoggedInUserId();


            var resultList = _todoService.TodoListWithDepartmentUserWhereDepartment(departmentId);

            return View(resultList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var list = await _departmentService.GetAllAsync();
            var todoStatusList = await _todoStatusService.GetAllAsync();
            ViewBag.DepartmentList = new SelectList(list, "Id", "Decription");
            ViewBag.todoStatusList = new SelectList(todoStatusList, "Id", "Description");


            return View(new TodoCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateDto todoCreateDto)
        {

            if (ModelState.IsValid)
            {
                todoCreateDto.AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId();
                var mappingEntity = _mapper.Map<Todo>(todoCreateDto);
                await _todoService.CreateAsync(mappingEntity);
                return RedirectToAction("Index", "Home");
            }
            var list = await _departmentService.GetAllAsync();
            var todoStatusList = await _todoStatusService.GetAllAsync();
            ViewBag.DepartmentList = new SelectList(list, "Id", "Decription");
            ViewBag.todoStatusList = new SelectList(todoStatusList, "Id", "Description");
            return View(todoCreateDto);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var entity = await _todoService.GetById(Id);
            var mappingEntity = _mapper.Map<TodoUpdateDto>(entity);
            var list = await _departmentService.GetAllAsync();
            var todoStatusList = await _todoStatusService.GetAllAsync();
            ViewBag.DepartmentList = new SelectList(list, "Id", "Decription");
            ViewBag.todoStatusList = new SelectList(todoStatusList, "Id", "Description");

            return View(mappingEntity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TodoUpdateDto dto)
        {
            dto.AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId();
            if(ModelState.IsValid)
            {
                await _todoService.Update(dto);
                return RedirectToAction("Index", "Home");
            }
            return View(dto);
            
        }


    }
}