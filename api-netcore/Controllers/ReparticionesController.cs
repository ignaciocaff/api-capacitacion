using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capacitacion.IServicios;
using Capacitacion.Modelos;
using Microsoft.AspNetCore.Http;
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

        [HttpGet, Route("obtener-reparticion/{idReparticion}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult GetById(int idReparticion)
        {
            try
            {
                var reparticion = _reparticionService.ObtenerReparticion(idReparticion);
                if (reparticion == null) return new NotFoundResult();
                return new OkObjectResult(reparticion);
            }
            catch (Exception)
            {
                return new ConflictResult();
            }
        }

        [HttpPost, Route("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult RegistrarReparticion([FromBody]Reparticion reparticion)
        {
            try
            {
                var insert = _reparticionService.RegistrarReparticion(reparticion);
                if (!insert) return new NotFoundResult();
                return new OkResult();
            }
            catch (Exception e)
            {
                return new ConflictObjectResult(e);
            }
        }

        [HttpGet, Route("obtener-sp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult ObtenerTodosSp()
        {
            try
            {
                var reparticiones = _reparticionService.ObtenerTodosSp();
                if (reparticiones == null || reparticiones.Count == 0) return new NotFoundResult();
                return new OkObjectResult(reparticiones);
            }
            catch (Exception)
            {
                return new ConflictResult();
            }
        }

    }
}
