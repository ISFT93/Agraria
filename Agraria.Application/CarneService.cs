using Agraria.Application.Interfaces;
using Agraria.Data.Repositories;
using Agraria.Data.Repositories.Interfaces;
using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Application
{
    public class CarneService : ICarneService
    {
        private readonly ICarneRepository _repo;
        public CarneService(ICarneRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Carne>> GetCarnes(CancellationToken cancellationToken = default)
        {
            var carnes = await _repo.GetAllAsync(cancellationToken);
            return carnes.ToList();
        }
    }
}
