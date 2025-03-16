using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task_backend.Core.Interfaces;
using Task_backend.Infrastructure.Data;
using Task_backend.Core.Entities;
using Task = System.Threading.Tasks.Task;


namespace Sales.infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Attributes

        public readonly DbTaskContext _context;
        private readonly DbSet<T> _entities;
        #endregion

        #region Construtor
        public Repository(DbTaskContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task DeleteAsync(string id)
        {
            T entity = await GetByIdAsync(id);
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            entity.Id = String.IsNullOrEmpty(entity.Id) ? Guid.NewGuid().ToString() : entity.Id;
            var date = DateTime.Now;

            entity.CreatedDate = date;
            
            await _entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            var date = DateTime.Now;
            entity.ModifiedDate = date;
            _entities.Update(entity);
        }
        
        
        #endregion
    }
}
