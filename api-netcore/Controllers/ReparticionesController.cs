using System.Collections.Generic;
using System.Threading.Tasks;
using Capacitacion.IServicios;
using Capacitacion.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace api_netcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparticionesController : ControllerBase
    {
        private readonly IReparticionService _reparticionService;

        public ReparticionesController(IReparticionService reparticionService)
        {
            _reparticionService = reparticionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Reparticion>> Get()
        {
            return await _reparticionService.ObtenerReparticiones();
        }
    }
}
