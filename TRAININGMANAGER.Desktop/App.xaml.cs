﻿using TRAININGMANAGER.Desktop.Views;
using TRAININGMANAGER.Desktop.Views.Login;
using TRAININGMANAGER.Desktop.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace TRAININGMANAGER.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly bool _loginPage = false;
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.ConfigureViewViewModels();
                    services.ConfigureHttpCliens();
                    services.ConfigureApiServices();
                })
                .Build();

        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            try
            {
                if (_loginPage)
                {
                    var loginView = host.Services.GetRequiredService<LoginView>();
                    loginView.Show();
                    loginView.IsVisibleChanged += (s, ev) =>
                    {
                        if (loginView.IsVisible == false && loginView.IsLoaded)
                        {
                            var mainView = host.Services.GetRequiredService<MainView>();
                            mainView.Show();

                            try
                            {
                                loginView.Close();
                            }
                            catch { }

                        }
                    };
                }
                else
                {
                    var mainView = host.Services.GetRequiredService<MainView>();
                    mainView.Show();
                }
            }
            catch (Exception)
            {
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync();
            host.Dispose();
            base.OnExit(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }
    }
}
