using AvaloniaRPG.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;

public partial class BackpackViewModel : PageViewModel
{
    [ObservableProperty]
    private string _test = "testowy backpack";
    
    public BackpackViewModel()
    {
        PageName = ApplicationPageNames.Backpack;
    }
}