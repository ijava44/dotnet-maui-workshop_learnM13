namespace MonkeyFinder.ViewModel;

public class BaseViewModel
{

}
```

to this

```csharp
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
}
public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy;
    string title;
    //...
}
public class BaseViewModel : INotifyPropertyChanged
{
    //...
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if (isBusy == value)
                return;
            isBusy = value;
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => title;
        set
        {
            if (title == value)
                return;
            title = value;
            OnPropertyChanged();
        }
    }
    //...
}
public class BaseViewModel : INotifyPropertyChanged
{
    //...
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if (isBusy == value)
                return;
            isBusy = value;
            OnPropertyChanged();
            // Also raise the IsNotBusy property changed
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public bool IsNotBusy => !IsBusy;
    //...
}
