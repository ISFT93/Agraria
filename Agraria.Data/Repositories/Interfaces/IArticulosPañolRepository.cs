using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface IArticulosPañolRepository 
    {
        Task<IEnumerable<ArticulosPañol>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ArticulosPañol?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(ArticulosPañol articulospañol, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(ArticulosPañol articulospañol, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
