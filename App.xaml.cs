global using Azure.Core;
global using Azure.Identity;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using HorizonHub.Controls;
global using HorizonHub.Helpers;
global using HorizonHub.Model;
global using HorizonHub.View;
global using HorizonHub.ViewModel;
global using HorizonHub.ViewModel.Pages;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Graph;
global using Microsoft.Graph.Models;
global using Microsoft.UI;
global using Microsoft.UI.Input;
global using Microsoft.UI.Windowing;
global using Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Controls;
global using Microsoft.UI.Xaml.Controls.Primitives;
global using Microsoft.UI.Xaml.Input;
global using Microsoft.UI.Xaml.Media;

global using Syncfusion.UI.Xaml.Scheduler;

global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Diagnostics;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;

global using Windows.Storage;

global using WinRT.Interop;

global using WinUIEx;

global using Application = Microsoft.UI.Xaml.Application;
global using Constants = HorizonHub.Helpers.Constants;

using Syncfusion.Licensing;

using System.IO;

namespace HorizonHub;

public partial class App : Application {

    public static ServiceProvider? Services { get; private set; }

    public App() {

        SyncfusionLicenseProvider.RegisterLicense(Constants.syncfusionKey);

        InitializeComponent();

        var services = new ServiceCollection();

        // Register Persistent Authentication with Token Caching

        services.AddSingleton(sp => {

            string authTokenPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.azureCalendarJsonName);
            AuthenticationRecord? authRecord = null;

            if(File.Exists(authTokenPath)) {
                using var authRecordStream = new FileStream(authTokenPath, FileMode.Open, FileAccess.Read);
                authRecord = AuthenticationRecord.Deserialize(authRecordStream);
            }

            var credentialOptions = new InteractiveBrowserCredentialOptions {
                TokenCachePersistenceOptions = new TokenCachePersistenceOptions { Name = Constants.azureCalendarToken },
                TenantId = "common",
                ClientId = Constants.clientID,
                RedirectUri = new Uri("http://localhost:3000"),
                AuthenticationRecord = authRecord // Pass authentication record if available
            };

            return new InteractiveBrowserCredential(credentialOptions);
        });

        // Register Microsoft Authentication Helper
        services.AddSingleton(sp => {
            var credential = sp.GetRequiredService<InteractiveBrowserCredential>();
            return new MicrosoftAuthHelper(credential);
        });

        // Register GraphServiceClient
        services.AddSingleton(sp => {
            var credential = sp.GetRequiredService<InteractiveBrowserCredential>();
            return new GraphServiceClient(credential);
        });


        // Register ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<CustomTitleBarViewModel>();
        services.AddTransient<CalendarPageViewModel>();
        services.AddTransient<AccountPageViewModel>();
        services.AddTransient<AboutPageViewModel>();

        // Register UI Components
        services.AddSingleton(sp => new CustomTitleBar(sp.GetRequiredService<CustomTitleBarViewModel>()));
        services.AddSingleton(sp => new MainWindow(sp.GetRequiredService<MainWindowViewModel>()));

        services.AddTransient(sp => new CalendarPage(sp.GetRequiredService<CalendarPageViewModel>()));
        services.AddTransient(sp => new AccountPage(sp.GetRequiredService<AccountPageViewModel>()));
        services.AddTransient(sp => new AboutPage(sp.GetRequiredService<AboutPageViewModel>()));

        Services = services.BuildServiceProvider();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args) {
        var mainWindow = Services?.GetService<MainWindow>();
        WidowsHelper.CreateWindow(mainWindow!, "ChronoSync");
    }
}
