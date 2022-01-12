using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using DomainLayer.Models;
using DomainLayer.Services;

using Microsoft.Toolkit.Mvvm.Input;

namespace WPFProjectTemplate.ViewModels.Admin;

public class UsersViewModel : ViewModelBase
{
    private readonly IRepository<AppUser> _userService;

    public UsersViewModel(IRepository<AppUser> userService)
    {
        _userService = userService;

        Users = new ObservableCollection<AppUser>();

        EditCommand = new RelayCommand<AppUser>(EditUser);
        DeleteCommand = new RelayCommand<AppUser>(DeleteUser);
    }

    public ObservableCollection<AppUser> Users { get; }

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    protected override async Task LoadViewModel() => (await _userService.GetAllAsync())
            .ToList()
            .ForEach(user => Users.Add(user));

    protected override void UnloadViewModel() => Users.Clear();

    private void EditUser(AppUser? obj)
    {
        throw new NotImplementedException();
    }

    private void DeleteUser(AppUser? obj)
    {
        throw new NotImplementedException();
    }
}
