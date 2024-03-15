using AspNetCoreHero.ToastNotification.Helpers;
using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;

namespace VideoPlayerLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCommentController : ControllerBase
    {
        private readonly ITodoCommentService _todoCommentService;

        public TodoCommentController(ITodoCommentService todoCommentService)
        {
            _todoCommentService = todoCommentService;
        }
        [HttpGet("todo-comments/{todoId}")]
        public async Task<IActionResult> GetTodoCommentList(int todoId)
        {
            var result = await _todoCommentService.TodoCommentsListWhereTodoId(todoId);
            return Ok(result.ToJson());
        }
    }
}
