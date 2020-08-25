using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Common.Data
{
    public interface IRepository<T> where T : Entity
    {
        bool Crear(T entity);
        bool Modificar(T entity);
        bool Eliminar(T entity);
        Task<T> ObtenerPorIdAsync(long id);
        Task<ICollection<T>> ObtenerTodoAsync();
        T ObtenerPorId(long id);
        ICollection<T> ObtenerTodo();
    }
}
