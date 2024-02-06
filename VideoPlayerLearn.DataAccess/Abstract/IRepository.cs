using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.DataAccess.Abstract
{
    public interface IRepository<T> where T :BaseEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<T> GetFindAsync(Expression<Func<T, bool>> filter);
        Task<T> GetById(int Id);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null);

        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity,T unchanged);
        void Update(int Id);
    }
}
