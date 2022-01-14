using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.Input;

using WPFProjectTemplate.Models;

namespace WPFProjectTemplate.ViewModels;

public class RolesViewModel : ViewModelBase
{
    private readonly IRepository<AccessRole> _roleService;

    public RolesViewModel(IRepository<AccessRole> roleService)
    {
        _roleService = roleService;

        Roles = new ObservableCollection<Role>();

        EditCommand = new RelayCommand<User>(EditRole);
        DeleteCommand = new RelayCommand<User>(DeleteRole);
    }

    public ObservableCollection<Role> Roles { get; }

    public ICommand EditCommand { get; }

    public ICommand DeleteCommand { get; }

    protected override async Task LoadViewModel()
    {
        try {
            var roles = await _roleService.GetAllAsync();
            foreach (var role in roles) {

            }
        }
        catch (Exception ex) {
            //...
        }
    }

    private void EditRole(User? obj)
    {
        throw new NotImplementedException();
    }

    private void DeleteRole(User? obj)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        Roles.Clear();
    }
}
