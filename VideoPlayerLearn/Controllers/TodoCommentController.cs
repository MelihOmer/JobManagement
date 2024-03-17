using AspNetCoreHero.ToastNotification.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Hubs;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCommentController : ControllerBase
    {
        private readonly IHubContext<TestHub> _hubContext;
        private readonly ITodoCommentService _todoCommentService;

        public TodoCommentController(ITodoCommentService todoCommentService, IHubContext<TestHub> hubContext)
        {
            _todoCommentService = todoCommentService;
            _hubContext = hubContext;
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
            await _hubContext.Clients.Users(todoCommentDto.AppUserId.ToString(),todoCommentDto.AssignedToUserId.ToString()).SendAsync("ReceiveMessage", $"{todoCommentDto.TodoId} Nolu Bildirime Yorum Eklenmiştir.");
            return Ok();
        }
    }
}
