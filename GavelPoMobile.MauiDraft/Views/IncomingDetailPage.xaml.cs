﻿namespace GavelPoMobile.MauiDraft.Views;

public partial class IncomingDetailPage : ContentPage
{
	public IncomingDetailPage(IncomingDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}