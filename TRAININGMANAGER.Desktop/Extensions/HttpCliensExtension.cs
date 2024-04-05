using Microsoft.Extensions.DependencyInjection;
using System;

namespace TRAININGMANAGER.Desktop.Extensions
{
    public static class HttpCliensExtension
    {
        public static void ConfigureHttpCliens(this IServiceCollection services)
        {
            services.AddHttpClient("TrainingManagerApi", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7090/");
            });
        }

    }
}