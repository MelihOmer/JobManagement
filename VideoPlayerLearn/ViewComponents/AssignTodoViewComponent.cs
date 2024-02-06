using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoPlayerLearn.Business.Abstract;

namespace VideoPlayerLearn.ViewComponents
{
    public class AssignTodoViewComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
