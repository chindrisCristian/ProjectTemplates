using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using WPFProjectTemplate.ViewModels;

namespace WPFProjectTemplate.Services;

public class NavigatorService : ObservableObject
{
    private enum ViewType
    {
        Main = 1,
        Users = 4,
        Roles = 5
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
            .GetResult()
            .ToList();

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
        ViewModelBase nextViewModel;
        try {
            switch (id) {
                case (int)ViewType.Main:
                    nextViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
                    break;
                case (int)ViewType.Users:
                    nextViewModel = _serviceProvider.GetRequiredService<UsersViewModel>();
                    break;
                case (int)ViewType.Roles:
                    nextViewModel = _serviceProvider.GetRequiredService<RolesViewModel>();
                    break;
                default:
                    throw new Exception($"Navigation error: {id} is not a valid index for a view!");
            }
            CurrentViewModel.Dispose();

            CurrentViewModel = nextViewModel;

            CurrentViewModel.IsReadOnly = _viewTypeAccesses
                .First(x => x.IdMenuItem == id)
                .IsReadOnly;
        }
        catch (Exception ex) {
            //handle exceptions...
        }
    }
}
