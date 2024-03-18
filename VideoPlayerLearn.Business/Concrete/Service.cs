using AutoMapper;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Business.Concrete
{
    public class Service<T> : IService<T> where T : BaseEntity, new()
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public Service(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _uow.GetRepository<T>().GetAllAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _uow.GetRepository<T>().CreateAsync(entity);
            await _uow.SaveChangeAsync();
        }
        public IQueryable<T> GetAllQueryable()
        {
            return _uow.GetRepository<T>().GetAllQueryable();
        }
        public async Task<T> GetById(int id)
        {

            var entity = await _uow.GetRepository<T>().GetById(id);
            return entity;
        }
        public async Task UpdateList(List<T> updatedList)
        {
            _uow.GetRepository<T>().Update(updatedList);
            await _uow.SaveChangeAsync();
        }
        

    }
}
