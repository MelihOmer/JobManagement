using AutoMapper;
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
    public class TodoStatusService : Service<TodoStatus>, ITodoStatusService
    {
        private readonly IUow _uow;
        public TodoStatusService(IUow uow,IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
        }

        public async Task<string> GetNameById(int Id)
        {
            var entity =await _uow.GetRepository<TodoStatus>().GetById(Id);
            return entity.Description;
        }

    }
}
