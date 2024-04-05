using TRAININGMANAGER.Desktop.ViewModels;
using TRAININGMANAGER.Desktop.ViewModels.ControlPanel;
using TRAININGMANAGER.Desktop.ViewModels.Login;
using TRAININGMANAGER.Desktop.ViewModels.Users;
using TRAININGMANAGER.Desktop.Views;
using TRAININGMANAGER.Desktop.Views.ControlPanel;
using TRAININGMANAGER.Desktop.Views.Login;
using TRAININGMANAGER.Desktop.Views.Users;
using Microsoft.Extensions.DependencyInjection;

namespace TRAININGMANAGER.Desktop.Extensions
{
    public static class ViewViewModelsExtensions
    {
        public static void ConfigureViewViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(s => new LoginView()
            {
                DataContext = s.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<ControlPanelViewModel>();
            services.AddSingleton<ControlPanelView>(s => new ControlPanelView()
            {
                DataContext = s.GetRequiredService<ControlPanelViewModel>()
            });
            services.AddSingleton<UsersViewModel>();
            services.AddSingleton<UsersView>(s => new UsersView()
            {
                DataContext = s.GetRequiredService<UsersViewModel>()
            });

            services.AddSingleton<PlayersViewModel>();
            services.AddSingleton<PlayersView>(s => new PlayersView()
            {
                DataContext = s.GetRequiredService<PlayersViewModel>()
            });

            services.AddSingleton<TrainersViewModel>();
            services.AddSingleton<PlayersView>(s => new PlayersView()
            {
                DataContext = s.GetRequiredService<TrainersViewModel>()
            });
        }
    }
}
