using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Entities.Dtos.TodoDtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoService : IService<Todo>
    {

        Task<IQueryable<Todo>> TodoListWithDepartmentUserWhereDepartmentAsync(int statusId);
        IQueryable<Todo> GetTodoListWithInclude(Expression<Func<Todo, bool>> filter = null);
        IQueryable<Todo> TodoListWithDepartmentUserWhereUserId(int userId);
        Task AssignTodoAsync(int todoId, int userId);
        IQueryable<Todo> TodoDetailsWithDepartmentUserComments(int Id);
        Task<int> CreateTodo(TodoCreateDto dto);
        Task<string> Update(TodoUpdateDto dto);
        Task TodoResolution(TodoResolutionDto dto);
        Task TodoAnalysis(TodoReviewDto dto);
        Task<Todo> TodoGetById(int Id);
        IQueryable<Todo> InJobPoolWhereDepartment(int departmentId);
        Task TodoRejected(TodoRejectedDto dto);
        IQueryable<Todo> TodoListWhereStatusId(int statusId);
    }
}
