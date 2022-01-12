using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainLayer.Models;
using DomainLayer.Services;

using WPFProjectTemplate.Services;

namespace WPFProjectTemplate.ViewModels;

public class MainViewModel : ViewModelBase
{

    public MainViewModel(NavigationViewModel navigation, 
        NavigatorService navigator)
    {
        Navigation = navigation;
        Navigator = navigator;
    }

    public NavigationViewModel Navigation { get; }

    public NavigatorService Navigator { get; }

    protected override async Task LoadViewModel()
    {
    }

    protected override void UnloadViewModel()
    {
    }
}
