using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.ViewComponents
{
    [ViewComponent]
    public class ResolutionViewComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(TodoDetailsWithTodoCommentsModel model)
        {
            return View();
        }


    }
}
