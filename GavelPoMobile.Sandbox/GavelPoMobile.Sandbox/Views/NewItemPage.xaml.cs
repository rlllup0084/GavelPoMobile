using GavelPoMobile.Sandbox.ViewModels;

namespace GavelPoMobile.Sandbox.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage {
        public NewItemPage() {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}