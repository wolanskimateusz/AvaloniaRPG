using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaRPG.Data;
using AvaloniaRPG.Factories;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Services;
using AvaloniaRPG.ViewModels;
using AvaloniaRPG.ViewModels.Inventory;
using AvaloniaRPG.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaRPG;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

        var collection = new ServiceCollection();
        // ViewModels
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<CharacterViewModel>();
        collection.AddTransient<ShopViewModel>();
        collection.AddTransient<RankingViewModel>();
        collection.AddTransient<SettingsViewModel>();
        collection.AddTransient<GuildViewModel>();
        collection.AddTransient<FightViewModel>();
        collection.AddTransient<BackpackViewModel>();
        collection.AddTransient<EquipmentViewModel>();
        
        
        // Services
        collection.AddSingleton<ICharacterService, FileCharacterService>();
        collection.AddSingleton<IEnemyService, EnemyService>();
        collection.AddSingleton<IFightService, FightService>();

        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Character => x.GetRequiredService<CharacterViewModel>(),
            ApplicationPageNames.Fight => x.GetRequiredService<FightViewModel>(),
            ApplicationPageNames.Ranking => x.GetRequiredService<RankingViewModel>(),
            ApplicationPageNames.Settings => x.GetRequiredService<SettingsViewModel>(),
            ApplicationPageNames.Guild => x.GetRequiredService<GuildViewModel>(),
            ApplicationPageNames.Shop  => x.GetRequiredService<ShopViewModel>(),
            
            _ => throw new InvalidOperationException(),
        });

        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}