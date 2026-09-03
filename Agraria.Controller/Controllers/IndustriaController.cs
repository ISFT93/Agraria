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
    public class IndustriaController : ControllerBase
    {
        private readonly IIndustriaService _service; // <- usar la interfaz

        public IndustriaController(IIndustriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Industria>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var industria = await _service.GetIndustria(cancellationToken);
                return Ok(industria);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
