using GavelPoMobile.Maui.ViewModels;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.Maui.Views {
    public partial class MainPage : Shell {
        public MainPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}