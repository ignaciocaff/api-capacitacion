using Capacitacion.Modelos;
using Core.Common.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capacitacion.IServicios
{
    public interface IReparticionService : ICommonServices
    {
        Task<ICollection<Reparticion>> ObtenerReparticiones();
    }
}
