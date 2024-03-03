using Microsoft.AspNetCore.Mvc;

namespace VideoPlayerLearn.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
