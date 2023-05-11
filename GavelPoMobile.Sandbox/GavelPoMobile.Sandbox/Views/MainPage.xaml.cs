using GavelPoMobile.Sandbox.ViewModels;
using System.Runtime.CompilerServices;

namespace GavelPoMobile.Sandbox.Views {
    public partial class MainPage : Shell {
        public MainPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}