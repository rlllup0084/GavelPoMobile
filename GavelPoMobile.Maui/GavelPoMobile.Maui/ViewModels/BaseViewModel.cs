using GavelPoMobile.Maui.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.Maui.ViewModels; 
public class BaseViewModel : INotifyPropertyChanged {

    bool isBusy = false;
    string title = string.Empty;

    public INavigationService Navigation => DependencyService.Get<INavigationService>();

    public ILoginService LoginService => DependencyService.Get<ILoginService>();

    public IPurchaseOrderService PurchaseOrderService => DependencyService.Get<IPurchaseOrderService>();

    public IAlertService AlertService => DependencyService.Get<IAlertService>();

    public bool IsBusy {
        get { return this.isBusy; }
        set { SetProperty(ref this.isBusy, value); }
    }

    public string Title {
        get { return this.title; }
        set { SetProperty(ref this.title, value); }
    }

    protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "") {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    protected bool SetProperty<T>(ref T backingStore, T value, Action<T, T> onChanged, [CallerMemberName] string propertyName = "") {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;
        T oldValue = backingStore;
        backingStore = value;
        onChanged?.Invoke(oldValue, value);
        OnPropertyChanged(propertyName);
        return true;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

}