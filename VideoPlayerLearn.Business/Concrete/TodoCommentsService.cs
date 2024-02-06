using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoCommentsService : Service<TodoComment>,ITodoCommentService
    {
        private readonly IUow _uow;

        public TodoCommentsService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
        }
        public async Task<List<TodoComment>> TodoCommentsList(int todoId)
        {
           var list =await _uow.GetRepository<TodoComment>().GetAllQueryable(x => x.TodoId == todoId).Include(x=> x.AppUser).ToListAsync();
            return list;
        }
    }
}
