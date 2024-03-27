using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoViewsUserService : IService<TodoViewsUser>
    {
        List<TodoViewsUserDto> GetViewsUserCountByTodoId(int Id);
    }
}
