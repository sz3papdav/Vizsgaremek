using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.Context
{
    public class TrainingManagerInMemoryContext : TrainingManagerContext
    {
        public TrainingManagerInMemoryContext(DbContextOptions<TrainingManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
