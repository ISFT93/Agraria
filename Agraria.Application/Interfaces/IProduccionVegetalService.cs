using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;


namespace Agraria.Application
{
    public interface IProduccionVegetalService
    {
        Task<List<ProduccionVegetal>> GetProduccionVegetal(CancellationToken cancellationToken = default);

    }
}
