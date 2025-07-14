using AvaloniaRPG.Data;
using AvaloniaRPG.Factories;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class MainWindowViewModel : ViewModelBase
{
    
    [ObservableProperty]
    private PageViewModel _currentPage;
    
    private readonly PageFactory _pageFactory;
    
    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        ShowCharacterView();
    }

    
    [RelayCommand]
    private void ShowCharacterView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Character);
    
    [RelayCommand]
    private void ShowFightView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Fight);
    
    [RelayCommand]
    private void ShowShopView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Shop);

    [RelayCommand]
    private void ShowRankingView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Ranking);

    [RelayCommand]
    private void ShowGuildView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Guild);
    
    [RelayCommand]
    private void ShowSettingsView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Settings);

}