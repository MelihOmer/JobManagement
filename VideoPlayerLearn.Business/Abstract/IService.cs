using VideoPlayerLearn.Entities.Common;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface IService<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();

        Task CreateAsync(T entity);

        IQueryable<T> GetAllQueryable();

        Task<T> GetById(int id);

        
    }
}
