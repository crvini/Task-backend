using Task_backend.Core.Interfaces;

namespace Task_backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties       
        
       
        IRepository<Task_backend.Core.Entities.Task> taskRepository { get; }
       
        
        #endregion

        #region Methods        
        int SaveChange();
        Task<int> SaveChangeAsync();
        #endregion

    }
}
