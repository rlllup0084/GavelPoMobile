using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views; 
public partial class AboutPage : ContentPage {
    public AboutPage() {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}