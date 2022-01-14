//using DapperDataAccess.Services;

using System.Windows;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WPFProjectTemplate.Extensions;
using WPFProjectTemplate.Services;
using WPFProjectTemplate.ViewModels;

namespace WPFProjectTemplate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = CreateHostBuilder()
            .Build();

        DispatcherUnhandledException += HandleExceptions;
    }

    public static IHostBuilder CreateHostBuilder(string[] args = null)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(c => {
                c.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) => {
                
                services.AddDAL(context.Configuration);

                services.AddRepositories();

                services.AddViewModels();

                services.AddSingleton(s => new NavigatorService(s));

                services.AddSingleton(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        Window window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }

    private void HandleExceptions(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message + e.Exception.InnerException?.Message + e.Exception.InnerException?.InnerException?.Message,
            "Ups...",
            MessageBoxButton.OK,
            MessageBoxImage.Asterisk);
        e.Handled = true;
    }
}
