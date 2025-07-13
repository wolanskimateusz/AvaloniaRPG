using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        CurrentViewModel = new CharacterViewModel();
    }
    
    [RelayCommand]
    private void ShowFightView()
    {
        CurrentViewModel =  new FightViewModel();
    }
    
    [RelayCommand]
    private void ShowCharacterView()
    {
        CurrentViewModel =  new CharacterViewModel();
    }
    
    [ObservableProperty]
    private ViewModelBase currentViewModel;
    
}