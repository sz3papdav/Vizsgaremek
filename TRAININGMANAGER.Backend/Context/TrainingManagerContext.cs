using TRAININGMANAGER.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.Context
{
    public class TrainingManagerContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Player> Players { get; set; }

        public TrainingManagerContext(DbContextOptions<TrainingManagerContext> options) : base(options)
        {
        }
    }
}
