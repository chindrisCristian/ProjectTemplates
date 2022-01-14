using System.Collections.ObjectModel;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPFProjectTemplate.Models;

public class Role : ObservableObject
{
    private AccessRole _role;

    public Role(AccessRole role)
    {
        _role = role;
    }

    public string RoleName {
        get => _role.RoleName;
        set => SetProperty(_role.RoleName, value, _role, (u, n) => u.RoleName = n);
    }

    public ObservableCollection<MenuItem> MenuItems { get; }
}
