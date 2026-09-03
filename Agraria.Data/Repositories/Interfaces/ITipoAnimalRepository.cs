using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agraria.Data.Repositories
{
    public interface ITipoAnimalRepository
    {
        Task<IEnumerable<TipoAnimal>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TipoAnimal?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(TipoAnimal tipoAnimal, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TipoAnimal tipoAnimal, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
