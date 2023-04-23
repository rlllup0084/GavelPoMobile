using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : ContentPage {
        public PopupPage() {
            InitializeComponent();
            BindingContext = new PopupViewModel();
        }

        void OnButtonClicked(object sender, EventArgs e) {
            Popup.IsOpen = true;
        }
    }
}