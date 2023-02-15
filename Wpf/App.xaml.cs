using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Features.Home;
using Wpf.Features.Navigation;
using Wpf.Features.Settings;

namespace Wpf;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<MainWindow>(sp => new MainWindow
        {
            DataContext = sp.GetRequiredService<MainViewModel>()
        });

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();
        
        services.AddSingleton<Func<Type, ViewModel>>(sp =>
            viewModelType => (ViewModel)sp.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }
}