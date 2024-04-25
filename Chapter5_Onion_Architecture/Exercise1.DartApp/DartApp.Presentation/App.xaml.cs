using DartApp.AppLogic;
using DartApp.AppLogic.Contracts;
using DartApp.Infrastructure.Storage;
using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace DartApp.Presentation
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var service = new ServiceCollection();
            service.AddTransient<MainWindow>();
            service.AddTransient<IPlayerRepository>(
                (x) => { return new PlayerFileRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"DartApp")); }
            );
            service.AddTransient<IPlayerService, PlayerService>();




            _serviceProvider = service.BuildServiceProvider();
            Console.WriteLine(service.ToString());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainwindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
        }
    }
}
