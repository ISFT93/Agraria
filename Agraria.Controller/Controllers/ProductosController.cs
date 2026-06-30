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
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _service; // <- usar la interfaz
        public ProductosController(IProductosService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var productos = await _service.GetProductos(cancellationToken);
                return Ok(productos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
