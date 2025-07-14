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
    private void ShowFightView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Fight);
    
    [RelayCommand]

    private void ShowCharacterView() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Character);




}