using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Application.Interfaces
{
    public interface ICarneService
    {
        Task<List<Carne>> GetCarnes(CancellationToken cancellationToken = default);
    }
}
