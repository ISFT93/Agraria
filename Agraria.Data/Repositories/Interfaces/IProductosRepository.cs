using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface IProductosRepository
    {
        Task<IEnumerable<Productos>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Productos?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(Productos productos, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Productos productos, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
