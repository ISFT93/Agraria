using Agraria.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;
using Agraria.Domain.Interfaces;

namespace Agraria.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IService _service;

        public Controller(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Practicas>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var practicas = await _service.GetPracticas(cancellationToken);
                return Ok(practicas);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
