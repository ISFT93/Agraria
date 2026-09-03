using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Agraria.Data.Repositories.Interfaces
{
    public interface IEngordeRepository
    {
        Task<IEnumerable<Engorde>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Engorde?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> CreateAsync(Engorde engorde, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(Engorde engorde, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
