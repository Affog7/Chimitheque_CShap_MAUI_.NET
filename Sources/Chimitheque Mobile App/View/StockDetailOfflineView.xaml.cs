using Chimitheque_Mobile_App.ViewModel;
namespace Chimitheque_Mobile_App.View;

public partial class StockDetailOfflineView : ContentPage
{
	public StockDetailOfflineView(StockDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}
