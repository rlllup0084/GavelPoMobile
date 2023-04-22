using GavelPoMobile.DXMaui.ViewModels;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.DXMaui.Views {
    public partial class MainPage : Shell {
        public MainPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}