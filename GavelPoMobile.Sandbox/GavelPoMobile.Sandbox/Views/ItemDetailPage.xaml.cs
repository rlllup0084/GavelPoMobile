using GavelPoMobile.Sandbox.ViewModels;

namespace GavelPoMobile.Sandbox.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}