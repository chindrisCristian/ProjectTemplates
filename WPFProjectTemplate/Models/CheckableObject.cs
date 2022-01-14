using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPFProjectTemplate.Models;

public class CheckableObject<T> : ObservableObject where T : class
{
    private bool _isChecked;

    public bool IsChecked {
        get => _isChecked;
        set => SetProperty(ref _isChecked, value);
    }

    public T Item { get; }

    public CheckableObject(T item)
    {
        Item = item;
    }
}
