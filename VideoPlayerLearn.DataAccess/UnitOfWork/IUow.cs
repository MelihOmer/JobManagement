using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.DataAccess.Abstract;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T: BaseEntity,new();
        Task SaveChangeAsync();
    }
}
