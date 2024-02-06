using Microsoft.AspNetCore.Mvc;

namespace VideoPlayerLearn.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
