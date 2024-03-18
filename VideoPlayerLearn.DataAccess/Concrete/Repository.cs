using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VideoPlayerLearn.DataAccess.Abstract;
using VideoPlayerLearn.DataAccess.Context;
using VideoPlayerLearn.Entities.Common;
namespace VideoPlayerLearn.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<T>().AsNoTracking().ToListAsync()
                : await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        public async Task<T> GetFindAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).SingleAsync();
        }
        public async Task<T> GetById(int Id)
        {
            
            return await _context.Set<T>().Where(x => x.Id == Id).SingleAsync();
        }
        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<T>().AsQueryable()
                : _context.Set<T>().Where(filter).AsQueryable();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
        public async void Update(int Id)
        {
            var entity = await GetById(Id);
            _context.Update(entity);
        }
        public  void Update(List<T> entites)
        {
            _context.Set<T>().UpdateRange(entites);
   
        }
    }
}
