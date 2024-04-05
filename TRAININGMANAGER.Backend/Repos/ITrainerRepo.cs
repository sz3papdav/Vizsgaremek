using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Parameters;

namespace TRAININGMANAGER.Backend.Repos
{
    public interface ITrainerRepo : IRepositoryBase<Trainer>
    {
        public IQueryable<Trainer> GetTrainers(TrainerQueryParameters parameters);
    }
}
