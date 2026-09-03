using Agraria.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;

namespace Agraria.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoAnimalController : ControllerBase
    {
        private readonly ITipoAnimalService _service; // <- usar la interfaz
        public TipoAnimalController(ITipoAnimalService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<TipoAnimal>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var tiposAnimales = await _service.GetTiposAnimales(cancellationToken);
                return Ok(tiposAnimales);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
