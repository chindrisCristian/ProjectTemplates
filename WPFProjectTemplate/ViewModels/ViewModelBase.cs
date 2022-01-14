using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using System.Threading.Tasks;

namespace WPFProjectTemplate.ViewModels;

public abstract class ViewModelBase : ObservableRecipient
{
    public ViewModelBase()
    {
        LoadCommand = new AsyncRelayCommand(LoadViewModel);
    }

    private bool _isReadOnly;

    public bool IsReadOnly {
        get => _isReadOnly;
        set => SetProperty(ref _isReadOnly, value);
    }


    public IAsyncRelayCommand LoadCommand { get; }
    protected abstract Task LoadViewModel();

    public abstract void Dispose();

}
