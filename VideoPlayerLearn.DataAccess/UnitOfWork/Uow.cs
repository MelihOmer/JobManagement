using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.DataAccess.Abstract;
using VideoPlayerLearn.DataAccess.Concrete;
using VideoPlayerLearn.DataAccess.Context;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AppDbContext _appDbContext;

        public Uow(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new Repository<T>(_appDbContext);
        }

        public async Task SaveChangeAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
