using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
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
            var list = await _uow.GetRepository<TodoComment>()
                .GetAllQueryable(x => x.TodoId == todoId)
                .Include(x => x.AppUser)
                .OrderByDescending(x=> x.Id)
                .ToListAsync();
            return list;
        }
    }
}
