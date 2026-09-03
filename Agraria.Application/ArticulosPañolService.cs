using Agraria.Data.Repositories;
using Agraria.Domain.Models;

namespace Agraria.Application
{

    public class ArticulosPañolService : IArticulosPañolService
    {
        private readonly IArticulosPañolRepository _repo;
        public ArticulosPañolService(IArticulosPañolRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<ArticulosPañol>> GetArticulosPañol(CancellationToken cancellationToken = default)
        {
            var articulospañol = await _repo.GetAllAsync(cancellationToken);
            return articulospañol.ToList();
        }
    }
}
