using Microsoft.EntityFrameworkCore;
using TRAININGMANAGER.Backend.Context;
using TRAININGMANAGER.Backend.Repos;

namespace TRAININGMANAGER.Backend.ContextRepos
{
    public class PlayerInMemoryRepo : PlayerRepo<TrainingManagerInMemoryContext>, IPlayerRepo
    {
        public PlayerInMemoryRepo(IDbContextFactory<TrainingManagerInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
