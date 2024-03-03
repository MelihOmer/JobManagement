using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoCommentsService : Service<TodoComment>, ITodoCommentService
    {
        private readonly IUow _uow;

        public TodoCommentsService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
        }
        public async Task<List<TodoComment>> TodoCommentsList(int todoId)
        {
            var list = await _uow.GetRepository<TodoComment>().GetAllQueryable(x => x.TodoId == todoId).Include(x => x.AppUser).ToListAsync();
            return list;
        }

        public async Task<List<TodoCommentNotifyDto>> NotifyCommentListByUserIdWhereNotSeen(string userId)
        {
            var list = _uow.GetRepository<TodoComment>().GetAllQueryable()
                .Include(i => i.Todo)
                .Where(x => x.Todo.AppUserId.ToString() == userId & !x.Seen);


            //List<TodoCommentNotifyDto> result = await list.Select(l => new TodoCommentNotifyDto 
            //{ Id = l.Id,
            //  Definition=l.Definition,
            //  AppUserId=l.Todo.AppUserId,
            //  AssignedUserId = l.Todo.AssignedToUserId
            //}).ToListAsync();
            return null;

        }
    }
}
