using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;

namespace Agraria.Application
{
    public interface ITipoEntornoService
    {
        Task<List<TipoEntorno>> GetTipoEntorno(CancellationToken cancellationToken = default);
    }
}
