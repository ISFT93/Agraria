using Agraria.Data.Repositories;
using Agraria.Domain.Interfaces;
using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Application
{
    public class Service : IService
    {
        private readonly IPracticaRepository _repo;
        public Service(IPracticaRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Practicas>> GetPracticas(CancellationToken cancellationToken = default)
        {
            var practicas = await _repo.GetAllAsync(cancellationToken);
            return practicas.ToList();
        }


    }
}
