using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;

namespace Agraria.Application
{
    public interface ILocalidadService
    {
        Task<List<Localidad>> GetLocalidades(CancellationToken cancellationToken = default);
    }
    public interface IService
    {
        Task<List<Practicas>> GetPracticas(CancellationToken cancellationToken = default);
    }
}

