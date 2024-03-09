using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities.Enums;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientNotificationsController : ControllerBase
    {
        private readonly IClientNotificationService _notificationService;

        public ClientNotificationsController(IClientNotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("bildirim-listesi")]
        public async Task<IActionResult> GetNotifyListForAppUserByTodoId([FromQuery]int notifyType, [FromQuery]int takeByNotifyCount)
        {
            var values = await _notificationService.GetNotifyListByTodoIdAsync((ClientNotficationType)notifyType);

            return Ok(values);
        }
        
    }
}
