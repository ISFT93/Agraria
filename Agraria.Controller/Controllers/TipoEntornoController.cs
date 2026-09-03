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
    public class TipoEntornoController : ControllerBase
    {
        private readonly ITipoEntornoService _service; // <- usar la interfaz

        public TipoEntornoController(ITipoEntornoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoEntorno>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var tipoentorno = await _service.GetTipoEntorno(cancellationToken);
                return Ok(tipoentorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
