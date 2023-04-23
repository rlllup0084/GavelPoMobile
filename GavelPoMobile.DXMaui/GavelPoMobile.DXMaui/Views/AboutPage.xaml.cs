using GavelPoMobile.DXMaui.ViewModels;

namespace GavelPoMobile.DXMaui.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AboutPage : ContentPage {
    public AboutPage() {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}