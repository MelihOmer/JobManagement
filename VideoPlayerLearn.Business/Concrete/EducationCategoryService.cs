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
    public class EducationCategoryService : Service<EducationCategory>, IEducationCategoryService
    {
        public EducationCategoryService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
        }

    }
}
