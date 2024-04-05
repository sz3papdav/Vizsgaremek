using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.Backend.Repos
{
    public interface IPlayerRepo : IRepositoryBase<Player>
    {
        public IQueryable<Player> GetTrainers(PlayerQueryParameters parameters);
    }
}
