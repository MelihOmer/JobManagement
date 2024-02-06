using Microsoft.AspNetCore.Mvc;

namespace VideoPlayerLearn.ViewComponents
{
    public class AnalysisViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
        
    }
}
