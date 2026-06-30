using Agraria.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface IIndustriaRepository
    {
        Task<IEnumerable<Industria>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Industria?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(Industria industria, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Industria industria, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
