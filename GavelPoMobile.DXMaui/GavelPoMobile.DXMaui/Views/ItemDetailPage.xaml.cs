﻿using GavelPoMobile.DXMaui.ViewModels;

namespace GavelPoMobile.DXMaui.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ItemDetailPage : ContentPage {
    public ItemDetailPage() {
        InitializeComponent();
        BindingContext = new ItemDetailViewModel();
    }
}