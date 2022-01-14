using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPFProjectTemplate.Models;

public class User : ObservableObject
{
    private AppUser _user;

    public User(AppUser user, IEnumerable<int> roles)
    {
        _user = user;
        AccessRoles = new ObservableCollection<int>(roles);
    }

    public string ContAD {
        get => _user.ContAD;
        set => SetProperty(_user.ContAD, value, _user, (u, n) => u.ContAD = n);
    }

    public ObservableCollection<int> AccessRoles { get; }
}
