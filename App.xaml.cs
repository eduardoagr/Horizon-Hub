global using Azure.Identity;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using HorizonHub.Controls;
global using HorizonHub.Helpers;
global using HorizonHub.Model;
global using HorizonHub.View;
global using HorizonHub.ViewModel;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Graph;
global using Microsoft.UI;
global using Microsoft.UI.Windowing;
global using Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Controls;
global using Microsoft.UI.Xaml.Media;

global using Syncfusion.Licensing;

global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;

global using Windows.Storage;

global using WinRT.Interop;

global using WinUIEx;

global using Constants = HorizonHub.Helpers.Constants;

namespace HorizonHub;

public partial class App : Application {

    public static ServiceProvider? Services { get; private set; }

    public App() {

        SyncfusionLicenseProvider.RegisterLicense(Constants.syncfusionKey);

        InitializeComponent();

        var services = new ServiceCollection();

        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<CustomTitleBarViewModel>();

        services.AddSingleton<CalendarPageViewModel>();

        services.AddSingleton(sp => new InteractiveBrowserCredential(
            new InteractiveBrowserCredentialOptions {
                ClientId = "eabe69e9-37fc-479a-976c-c699b3f3db5c",
                TenantId = "consumers",
                RedirectUri = new Uri("http://localhost:3000"),
            }
        ));

        services.AddSingleton(sp => {
            var titleBarViewModel = sp.GetRequiredService<CustomTitleBarViewModel>();
            return new CustomTitleBar(titleBarViewModel);
        });

        services.AddSingleton(sp => {
            var mainViewModlel = sp.GetRequiredService<MainWindowViewModel>();
            return new MainWindow(mainViewModlel);
        });

        services.AddSingleton(sp => {
            var calendarPageViewModel = sp.GetRequiredService<CalendarPageViewModel>();
            return new CalendarPage(calendarPageViewModel);
        });

        // Register GraphServiceClient using the Authentication Provider
        services.AddSingleton(sp => {
            var authProvider = sp.GetRequiredService<InteractiveBrowserCredential>();
            return new GraphServiceClient(authProvider);
        });



        Services = services.BuildServiceProvider();

    }

    protected override void OnLaunched(LaunchActivatedEventArgs args) {

        var mainWindow = Services?.GetService<MainWindow>();

        WidowsHelper.CreateWindow(mainWindow!, "ChronoSync");
    }
}
