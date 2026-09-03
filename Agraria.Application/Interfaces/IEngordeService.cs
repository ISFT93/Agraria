using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Application.Interfaces
{
    public interface IEngordeService
    {
        Task<List<Engorde>> GetEngorde(CancellationToken cancellationToken = default);
    }
}
