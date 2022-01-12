using System;
using System.Collections.Generic;
using System.Linq;

using DomainLayer.Models;
using DomainLayer.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using WPFProjectTemplate.ViewModels;

namespace WPFProjectTemplate.Services;

public class NavigatorService : ObservableObject
{
    private enum ViewType
    {
        Main = 5,
        v = 2
    }

    private readonly IServiceProvider _serviceProvider;
    private IEnumerable<ViewTypeAccess> _viewTypeAccesses;

    public NavigatorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _viewTypeAccesses = serviceProvider
            .GetRequiredService<IRepository<ViewTypeAccess>>()
            .GetAllAsync()
            .GetAwaiter()
            .GetResult();

        _currentViewModel = serviceProvider.
            GetRequiredService<HomeViewModel>();
    }

    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public void NavigateTo(int id)
    {
        try {
            switch (id) {
                case (int)ViewType.Main:
                    CurrentViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
                    break;
                default:
                    break;
            }
            CurrentViewModel.IsReadOnly = _viewTypeAccesses
                .First(x => x.IdMenuItem == id)
                .IsReadOnly;
        }
        catch (Exception ex) {
            //handle exceptions...
        }
    }
}
