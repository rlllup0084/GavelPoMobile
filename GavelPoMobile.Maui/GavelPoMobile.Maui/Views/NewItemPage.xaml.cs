using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage {
        public NewItemPage() {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}