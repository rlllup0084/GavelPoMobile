namespace GavelPoMobile.Maui.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class IncomingDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
