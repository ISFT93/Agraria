using Agraria.Data.Repositories;
using Agraria.Domain.Models;

namespace Agraria.Application
{
    
    public class LocalidadService:ILocalidadService
    {
        private readonly ILocalidadRepository _repo;
        public LocalidadService(ILocalidadRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<Localidad>> GetLocalidades(CancellationToken cancellationToken = default)
        {
            var localidades = await _repo.GetAllAsync(cancellationToken);
            return localidades.ToList();
        }

    }
}
