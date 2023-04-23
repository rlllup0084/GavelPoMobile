namespace GavelPoMobile.Maui.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class HistoryDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
