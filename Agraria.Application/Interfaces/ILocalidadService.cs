using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Models;

namespace Agraria.Application
{
    public interface ILocalidadService
    {
        Task<List<Localidad>> GetLocalidades(CancellationToken cancellationToken = default);
    }
}