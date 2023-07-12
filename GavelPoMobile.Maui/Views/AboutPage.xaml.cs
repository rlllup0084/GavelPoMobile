using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views; 
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AboutPage : ContentPage {
    public AboutPage() {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}