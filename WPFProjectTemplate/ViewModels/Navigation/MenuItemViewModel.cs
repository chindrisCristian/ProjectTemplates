using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using DomainLayer.Models;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using WPFProjectTemplate.Services;

namespace WPFProjectTemplate.ViewModels;

public class MenuItemViewModel : ObservableObject
{
    private readonly NavigatorService _navigator;

    public MenuItem Item { get; }

    public ObservableCollection<MenuItemViewModel> SubItems { get; }

    public ICommand ChangeViewCmd { get; }

    public MenuItemViewModel(MenuItem item,
        ObservableCollection<MenuItemViewModel> subItems,
        NavigatorService navigator)
    {
        _navigator = navigator;

        Item = item;
        SubItems = subItems;

        ChangeViewCmd = new RelayCommand(ChangeView);
    }

    private void ChangeView()
    {
        _navigator.NavigateTo(Item.Id);
    }
}
