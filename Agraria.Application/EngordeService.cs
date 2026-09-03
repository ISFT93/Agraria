using Agraria.Data.Repositories;
using Agraria.Domain.Models;
using Agraria.Application.Interfaces;
using Agraria.Data.Repositories.Interfaces;

namespace Agraria.Application
{
    public class EngordeService:IEngordeService
    {
        private readonly IEngordeRepository _repo;
        public EngordeService(IEngordeRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Engorde>> GetEngorde(CancellationToken cancellationToken)
        {
            var engorde = await _repo.GetAllAsync(cancellationToken);
            return engorde.ToList();
        }
    }
}
