using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;

namespace Agraria.Data.Repositories
{
    public interface IProduccionVegetalRepository
    {
        Task<IEnumerable<ProduccionVegetal>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ProduccionVegetal?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> CreateAsync(ProduccionVegetal produccionVegetal, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ProduccionVegetal produccionVegetal, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
