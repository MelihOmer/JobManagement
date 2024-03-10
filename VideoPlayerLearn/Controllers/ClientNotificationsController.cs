using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities.Enums;
using VideoPlayerLearn.Hubs;
using VideoPlayerLearn.Models.StatusMessageAjax;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientNotificationsController : ControllerBase
    {
        private readonly IClientNotificationService _notificationService;
        private readonly IStatusMessageService _statusMessageService;
        private readonly IHubContext<StateHub> _stateHub;

        public ClientNotificationsController(IClientNotificationService notificationService, IStatusMessageService statusMessageService, IHubContext<StateHub> stateHub)
        {
            _notificationService = notificationService;
            _statusMessageService = statusMessageService;
            _stateHub = stateHub;
        }
        [HttpGet("bildirim-listesi")]
        public async Task<IActionResult> GetNotifyListForAppUserByTodoId([FromQuery] int notifyType, [FromQuery] int takeByNotifyCount)
        {
            var values = await _notificationService.GetNotifyListByTodoIdAsync((ClientNotficationType)notifyType);

            return Ok(values);
        }
        [HttpGet("status-messagelist")]
        public async Task<IActionResult> GetStatusMessageList()
        {
            var values = await _statusMessageService.GetStatusMessageAsync();
            var reverseList = values.OrderBy(x => x.Id);
            return Ok(reverseList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatusMessageAndSendSignalR(StatusMessageAjaxPost statusMessage)
        {
            var signalRdata = await _statusMessageService.CreateStatusMessage(statusMessage.StatusMessage);
            await _stateHub.Clients.All.SendAsync("ReceiveState", signalRdata);
            return Ok();

        }


    }
}
