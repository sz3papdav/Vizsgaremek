using TRAININGMANAGER.Backend.Context;
using TRAININGMANAGER.Backend.ContextRepos;
using TRAININGMANAGER.Backend.Controllers.Assamblers;
using TRAININGMANAGER.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace TRAININGMANAGER.Backend.Extensions
{
    public static class TrainingManagerBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "TrainingManagerCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "TRAININGMANAGER" + Guid.NewGuid();
            services.AddDbContextFactory<TrainingManagerContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
            services.AddDbContextFactory<TrainingManagerInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<ITrainerRepo, TrainerInMemoryRepo>();
            services.AddScoped<IPlayerRepo, PlayerInMemoryRepo>();
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<TrainerAssambler>();
            services.AddScoped<PlayerAssambler>();
        }
    }
}
