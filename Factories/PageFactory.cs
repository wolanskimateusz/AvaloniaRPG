using System;
using AvaloniaRPG.Data;
using AvaloniaRPG.ViewModels;

namespace AvaloniaRPG.Factories;

public class PageFactory
{
    private readonly Func<ApplicationPageNames, PageViewModel> _factory;
    
    public PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
    {
        _factory = factory;
    }

    public PageViewModel GetPageViewModel(ApplicationPageNames name) => _factory.Invoke(name);
}