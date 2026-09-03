using Agraria.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;
using Agraria.Domain.Interfaces;
using Agraria.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Agraria.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EngordeController : ControllerBase
    {
        private readonly IEngordeService _service;

        public EngordeController(IEngordeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Engorde>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var engorde = await _service.GetEngorde(cancellationToken);
                return Ok(engorde);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
