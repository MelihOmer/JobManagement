using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IUow _uow;
        public DepartmentService(IUow uow,IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
        }

        public List<Department> DepartmentList()
        {
            return _uow.GetRepository<Department>().GetAllQueryable(x => x.Id != 1).ToList();
        }


    }
}

