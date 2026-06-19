using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;
using Agraria.Data.Repositories;

namespace Agraria.Application
{
    public class ProduccionVegetalService
    {
        private readonly IProduccionVegetalRepository _repo;
        public ProduccionVegetalService(IProduccionVegetalRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<ProduccionVegetal>> GetProduccionVegetal(CancellationToken cancellationToken = default)
        {
            var produccionvegetal = await _repo.GetAllAsync(cancellationToken);
            return produccionvegetal.ToList();
        }
    }
}
