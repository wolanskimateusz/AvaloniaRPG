using AvaloniaRPG.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ApplicationPageNames _pageName;
}