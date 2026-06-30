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
    public class ArticulosPañolController : ControllerBase
    {
        private readonly IArticulosPañolService _service; // <- usar la interfaz

        public ArticulosPañolController(IArticulosPañolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticulosPañol>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var articulospañol = await _service.GetArticulosPañol(cancellationToken);
                return Ok(articulospañol);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
