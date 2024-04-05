using TRAININGMANAGER.HttpService.Service;
using Microsoft.Extensions.DependencyInjection;

namespace TRAININGMANAGER.Desktop.Extensions
{
    public static class ApiServiceExtensions
    {
        public static void ConfigureApiServices(this IServiceCollection services)
        {
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IPlayerService, PlayerService>();
        }
    }
}