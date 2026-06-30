using Agraria.Data.Repositories;
using Agraria.Domain.Models;

namespace Agraria.Application
{
    public class TipoAnimalService : ITipoAnimalService
    {
        private readonly ITipoAnimalRepository _repo;
        public TipoAnimalService(ITipoAnimalRepository repo)
        {
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }
        public async Task<List<TipoAnimal>> GetTiposAnimales(CancellationToken cancellationToken = default)
        {
            var tiposAnimales = await _repo.GetAllAsync(cancellationToken);
            return tiposAnimales.ToList();
        }
    }
    

}
