using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views;

public partial class LoginPage : ContentPage {
    public LoginPage() {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}