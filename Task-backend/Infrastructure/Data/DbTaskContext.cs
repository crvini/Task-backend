using Microsoft.EntityFrameworkCore;

namespace Task_backend.Infrastructure.Data
{
    public class DbTaskContext : DbContext
    {
        #region Constructor        
        public DbTaskContext(DbContextOptions<DbTaskContext> options) : base(options){        
        }        
        #endregion
        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
        #endregion
        
        #region Properties        
        public DbSet<Task_backend.Core.Entities.Task> Tasks{ get; set; }
       
        #endregion
    }
}
