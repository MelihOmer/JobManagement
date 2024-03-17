using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoCommentService : IService<TodoComment>
    {
        Task<List<TodoComment>> TodoCommentsList(int todoId);
        Task<List<TodoCommentResultDto>> TodoCommentsListWhereTodoId(int todoId);
        Task TodoCommentCreateAsync(TodoCommentCreateDto todoCommentCreateDto);
    }
}
