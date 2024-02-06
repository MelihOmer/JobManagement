using Microsoft.AspNetCore.Mvc;

namespace VideoPlayerLearn.ViewComponents
{
    public class RejectedTodoViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
