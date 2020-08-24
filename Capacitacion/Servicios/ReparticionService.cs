using Capacitacion.IRepositorios;
using Capacitacion.IServicios;
using Capacitacion.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capacitacion.Servicios
{
    public class ReparticionService : IReparticionService
    {
        private readonly IReparticionRepositorio _reparticionRepository;

        public ReparticionService(IReparticionRepositorio reparticionRepository)
        {
            _reparticionRepository = reparticionRepository;
        }
        public async Task<ICollection<Reparticion>> ObtenerReparticiones()
        {
            return await _reparticionRepository.GetAllAsync();
        }
    }
}
