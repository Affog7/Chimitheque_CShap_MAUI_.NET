using Chimitheque_Mobile_App.ViewModel;
using CommunityToolkit.Maui.Views;

namespace Chimitheque_Mobile_App.View;

public partial class StockDetailView : ContentPage
{
    public StockDetailView(StockDetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}