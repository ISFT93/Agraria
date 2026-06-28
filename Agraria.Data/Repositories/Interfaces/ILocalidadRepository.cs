using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface ILocalidadRepository
    {
        Task<IEnumerable<Localidad>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Localidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(Localidad localidad, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Localidad localidad, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}