using AspNetCoreHero.ToastNotification.Helpers;
using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.HubManager;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCommentController : ControllerBase
    {

        private readonly ITodoCommentService _todoCommentService;
        private readonly TestHubManager _testHubManager;
        readonly IClientNotificationService _clientNotificationService;

        public TodoCommentController(ITodoCommentService todoCommentService, TestHubManager testHubManager, IClientNotificationService clientNotificationService)
        {
            _todoCommentService = todoCommentService;
            _testHubManager = testHubManager;
            _clientNotificationService = clientNotificationService;
        }
        [HttpGet("todo-comments/{todoId}")]
        public async Task<IActionResult> GetTodoCommentList(int todoId)
        {
            var result = await _todoCommentService.TodoCommentsListWhereTodoId(todoId);
            return Ok(result.ToJson());
        }
        [HttpPost]
        public async Task<IActionResult> AddTodoComment([FromBody]TodoCommentCreateDto todoCommentDto)
        {
            await _todoCommentService.TodoCommentCreateAsync(todoCommentDto);
            await _testHubManager.AfterAddingCommentNotify(todoCommentDto.AppUserId, todoCommentDto.AssignedToUserId, todoCommentDto.TodoId);
            await _clientNotificationService.CustomCreateAsync(new(todoId:todoCommentDto.TodoId,appUserId:todoCommentDto.AppUserId,assignedToUserId:todoCommentDto.AssignedToUserId));
            return Ok();
        }
    }
}
