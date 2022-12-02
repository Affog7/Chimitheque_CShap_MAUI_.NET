using Chimitheque_Mobile_App.ViewModel;
using Microsoft.Maui.Controls;

namespace Chimitheque_Mobile_App.View;

public partial class SearchProductView : ContentPage
{
	public SearchProductView(SearchProductViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}