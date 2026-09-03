using Agraria.Data.Repositories;
using Agraria.Domain.Models;

namespace Agraria.Application
{

    public class IndustriaService : IIndustriaService
    {
        private readonly IIndustriaRepository _repo;
        public IndustriaService(IIndustriaRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Industria>> GetIndustria(CancellationToken cancellationToken = default)
        {
            var industria = await _repo.GetAllAsync(cancellationToken);
            return industria.ToList();
        }
    }
}
