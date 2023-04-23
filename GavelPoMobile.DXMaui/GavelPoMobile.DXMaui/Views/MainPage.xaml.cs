using GavelPoMobile.DXMaui.ViewModels;

namespace GavelPoMobile.DXMaui.Views;
public partial class MainPage : Shell {
    public MainPage() {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}