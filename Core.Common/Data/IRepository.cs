using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Common.Data
{
    public interface IRepository<T> where T : Entity
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<T> GetByIdAsync(long id);
        Task<ICollection<T>> GetAllAsync();
        T GetById(long id);
        ICollection<T> GetAll();
    }
}
