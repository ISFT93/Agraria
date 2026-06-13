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
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _service; // <- usar la interfaz

        public LocalidadController(ILocalidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Localidad>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var localidades = await _service.GetLocalidades(cancellationToken);
                return Ok(localidades);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}