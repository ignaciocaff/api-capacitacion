using Capacitacion.Modelos;
using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capacitacion.IRepositorios
{
    public interface IReparticionRepositorio : IRepository<Reparticion>
    {
        ICollection<Reparticion> ObtenerTodosSp();
    }
}
