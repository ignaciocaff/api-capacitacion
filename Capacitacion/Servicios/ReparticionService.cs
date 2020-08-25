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

        public Reparticion ObtenerReparticion(long idReparticion)
        {
            return _reparticionRepository.ObtenerPorId(idReparticion);
        }

        public async Task<ICollection<Reparticion>> ObtenerReparticiones()
        {
            return await _reparticionRepository.ObtenerTodoAsync();
        }

        public bool RegistrarReparticion(Reparticion reparticion)
        {
            return _reparticionRepository.Crear(reparticion);
        }
        public ICollection<Reparticion> ObtenerTodosSp()
        {
            return _reparticionRepository.ObtenerTodosSp();
        }
    }
}
