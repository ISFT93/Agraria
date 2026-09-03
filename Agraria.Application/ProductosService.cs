using Agraria.Data.Repositories;
using Agraria.Domain.Models;

namespace Agraria.Application
{

    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _repo;
        public ProductosService(IProductosRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Productos>> GetProductos(CancellationToken cancellationToken = default)
        {
            var productos = await _repo.GetAllAsync(cancellationToken);
            return productos.ToList();
        }
    }
}
