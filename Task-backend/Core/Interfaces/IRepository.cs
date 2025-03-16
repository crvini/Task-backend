using System.Linq.Expressions;
using Task_backend.Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace Task_backend.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {       
        Task<IEnumerable<T?>> GetAllAsync();        
        Task<T?> GetByIdAsync(string id);        
        Task InsertAsync(T? entity);
        void Update(T? entity);
        Task DeleteAsync(string id);
        
        
    }
}
