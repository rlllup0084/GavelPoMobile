using GavelPoMobile.Maui.Models;
using GavelPoMobile.Maui.ViewModels;

namespace GavelPoMobile.Maui.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage {
        public ItemsPage() {
            InitializeComponent();
            BindingContext = ViewModel = new ItemsViewModel();
            ViewModel.OnAppearing();
        }

        ItemsViewModel ViewModel { get; }

        protected override void OnAppearing() {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}