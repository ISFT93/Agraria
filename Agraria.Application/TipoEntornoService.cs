using Agraria.Data.Repositories;
using Agraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Application
{
    internal class TipoEntornoService : ITipoEntornoService
    {
        private readonly ITipoEntornoRepository _repo;
        public TipoEntornoService(ITipoEntornoRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<TipoEntorno>> GetTipoEntorno(CancellationToken cancellationToken = default)
        {
            var tipoentorno = await _repo.GetAllAsync(cancellationToken);
            return tipoentorno.ToList();
        }

    }
}
