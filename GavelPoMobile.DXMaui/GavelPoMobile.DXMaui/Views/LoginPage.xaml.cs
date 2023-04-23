using GavelPoMobile.DXMaui.ViewModels;

namespace GavelPoMobile.DXMaui.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class LoginPage : ContentPage {
    public LoginPage() {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}