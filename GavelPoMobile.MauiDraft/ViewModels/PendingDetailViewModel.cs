namespace GavelPoMobile.MauiDraft.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class PendingDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
