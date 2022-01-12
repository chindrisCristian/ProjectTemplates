using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using DomainLayer.Models;
using DomainLayer.Services;

using WPFProjectTemplate.Services;

namespace WPFProjectTemplate.ViewModels;

public class NavigationViewModel : ViewModelBase
{
    private readonly IRepository<MenuItem> _menuItemService;
    private readonly NavigatorService _navigator;

    public NavigationViewModel(IRepository<MenuItem> menuItemService,
        NavigatorService navigator)
    {
        _menuItemService = menuItemService;
        _navigator = navigator;
        
        MenuItems = new ObservableCollection<MenuItemViewModel>();
    }

    public ObservableCollection<MenuItemViewModel> MenuItems { get; }

    protected override async Task LoadViewModel()
    {
        try {
            var menuItems = await _menuItemService.GetAllAsync();

            foreach (var item in CreateMenuItemCollection(menuItems, null)) {
                MenuItems.Add(item);
            }
        }
        catch(Exception e) {
            //handle errors
        }
    }

    private IEnumerable<MenuItemViewModel> CreateMenuItemCollection(IEnumerable<MenuItem> menuItems, int? parentId)
    {
        var result = menuItems.Where(x => x.IdParent == parentId)
            .Select(x => new MenuItemViewModel(x, 
                new ObservableCollection<MenuItemViewModel>(CreateMenuItemCollection(menuItems, x.Id)),
                _navigator));

        return result;
    }

    protected override void UnloadViewModel()
    {
        throw new System.NotImplementedException();
    }
}
