using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.Input;

using WPFProjectTemplate.Models;

namespace WPFProjectTemplate.ViewModels;

public class UsersViewModel : ViewModelBase
{
    private readonly IRepository<AppUser> _userService;
    private readonly IRepository<AccessRole> _roleService;

    public UsersViewModel(IRepository<AppUser> userService, 
        IRepository<AccessRole> roleService)
    {
        _userService = userService;
        _roleService = roleService;

        Users = new ObservableCollection<User>();
        Roles = new ObservableCollection<CheckableObject<AccessRole>>();

        SaveCommand = new RelayCommand(SaveUser);
        EditCommand = new RelayCommand(EditUser);
        DeleteCommand = new RelayCommand<User>(DeleteUser);
    }

    public ObservableCollection<User> Users { get; }

    private User _selectedItem;
    public User SelectedItem {
        get => _selectedItem;
        set {
            SetProperty(ref _selectedItem, value);
            SelectedItemChanged();
        }
    }

    public ObservableCollection<CheckableObject<AccessRole>> Roles { get; }


    public ICommand SaveCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    protected override async Task LoadViewModel()
    {
        try {
            (await _roleService.GetAllAsync())
                .ToList()
                .ForEach(x => Roles.Add(new CheckableObject<AccessRole>(x)));

            var users = await _userService.GetAllAsync();
            foreach (var user in users) {
                var roles = await _roleService.GetAsync(QueryType.WithParam, user.Id);
                Users.Add(new User(user, roles.Select(x => x.Id)));
            }
        }
        catch (Exception ex) {
            //...
        }
    }

    private void SelectedItemChanged()
    {
        foreach (var item in Roles) {
            item.IsChecked = SelectedItem.AccessRoles.Contains(item.Item.Id);
        }
    }

    private void SaveUser()
    {
        throw new NotImplementedException();
    }

    private void EditUser()
    {
        throw new NotImplementedException();
    }

    private void DeleteUser(User? obj)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        Users.Clear();
        Roles.Clear();
    }
}
