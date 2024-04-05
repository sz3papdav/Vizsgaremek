using TRAININGMANAGER.Backend.Context;
using TRAININGMANAGER.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.ContextRepos
{
    public class TrainerInMemoryRepo : TrainerRepo<TrainingManagerInMemoryContext>, ITrainerRepo
    {
        public TrainerInMemoryRepo(IDbContextFactory<TrainingManagerInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
