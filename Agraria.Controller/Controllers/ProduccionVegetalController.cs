using Agraria.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Agraria.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduccionVegetalController : ControllerBase
    {
            private readonly ProduccionVegetalService _service; // <- usar la interfaz
    
            public ProduccionVegetalController(ProduccionVegetalService service)
            {
                _service = service;
            }
    
            [HttpGet]
            public async Task<ActionResult<List<ProduccionVegetal>>> Get(CancellationToken cancellationToken)
            {
                try
                {
                    var produccionvegetal = await _service.GetProduccionVegetal(cancellationToken);
                    return Ok(produccionvegetal);
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
        }
    }
}
