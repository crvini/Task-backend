using Microsoft.EntityFrameworkCore.Storage;
using Sales.infrastructure.Repositories;
using Task_backend.Core.Interfaces;
using Task_backend.Infrastructure.Data;
using Task_backend.Core.Interfaces;


namespace Task_backend.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes
        private readonly DbTaskContext _context;
        private IDbContextTransaction _transaction;
        #endregion

        #region Constructor
        public UnitOfWork(DbTaskContext context)
        {
            _context = context;
        }

        #endregion
        
        
        
        public IRepository<Task_backend.Core.Entities.Task> taskRepository => new Repository<Task_backend.Core.Entities.Task>(_context);
        
        public void Dispose()
        {
            
            if (_transaction is not null)
            {
                _transaction.Dispose();
            }
        }
        public int SaveChange() => _context.SaveChanges();
        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();

        

        
    }
}
