using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories.Interfaces
{
    public interface ICarneRepository
    {
        Task<IEnumerable<Carne>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Carne?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(Carne carne, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Carne carne, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
