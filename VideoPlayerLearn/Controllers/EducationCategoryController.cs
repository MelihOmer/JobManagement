using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.Controllers
{
    public class EducationCategoryController : Controller
    {
        private readonly IEducationCategoryService _educationCategoryService;

        public EducationCategoryController(IEducationCategoryService educationCategoryService, ITodoCommentService todoCommentService)
        {
            _educationCategoryService = educationCategoryService;

        }

        public async Task<IActionResult> IndexAsync()
        {
            EducationCategoryCreateListModel model = new EducationCategoryCreateListModel()
            {
                EducationCategories = await _educationCategoryService.GetAllAsync()
            };


            return View(model);
        }
        public async Task<IActionResult> Create(EducationCategoryCreateListModel model)
        {
            if (!string.IsNullOrEmpty(model.EducationCategory.Title))
            {
                await _educationCategoryService.CreateAsync(model.EducationCategory);
            }
           

            return RedirectToAction("Index", "EducationCategory");
        }
    }
}
