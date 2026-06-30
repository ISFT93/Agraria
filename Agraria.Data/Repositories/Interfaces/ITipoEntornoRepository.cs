using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface ITipoEntornoRepository
    {
        Task<IEnumerable<TipoEntorno>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TipoEntorno?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(TipoEntorno tipoEntorno, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TipoEntorno tipoEntorno, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
