using TRAININGMANAGER.Backend.Context;
using TRAININGMANAGER.Shared.Models;
using TRAININGMANAGER.Shared.Parameters;
using TRAININGMANAGER.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace TRAININGMANAGER.Backend.Repos
{
    public class PlayerRepo<TDbConstext> : RepositoryBase<TDbConstext, Player>, IPlayerRepo
        where TDbConstext : DbContext
    {
        public PlayerRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IQueryable<Player> GetTrainers(PlayerQueryParameters parameters)
        {
            IQueryable<Player> filteredTrainer = FindByCondition(player => player.BirthsDay.Year >= parameters.MinYearOfBirth
                                           && player.BirthsDay.Year <= parameters.MaxYearOfBirth
                                  )
                                  .OrderBy(player => player.HungarianFullName);

            SearchByTrainerName(ref filteredTrainer, parameters.Name);
            return filteredTrainer;
        }

        private void SearchByTrainerName(ref IQueryable<Player> players, string playerName)
        {
            if (!players.Any() || string.IsNullOrEmpty(playerName))
            {
                return;
            }
            players = players.Where(student => student.HungarianFullName.ToLower().Contains(playerName.Trim().ToLower()));
        }
    }
}
