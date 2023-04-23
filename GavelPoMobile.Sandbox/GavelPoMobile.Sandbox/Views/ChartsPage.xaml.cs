﻿using GavelPoMobile.Sandbox.ViewModels;

namespace GavelPoMobile.Sandbox.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartsPage : ContentPage {
        public ChartsPage() {
            InitializeComponent();
            BindingContext = ViewModel = new ChartsViewModel();
            ViewModel.OnAppearing();
        }

        ChartsViewModel ViewModel { get; }

        protected override void OnAppearing() {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}