using Chimitheque_Mobile_App.ViewModel;
using CommunityToolkit.Maui.Views;

namespace Chimitheque_Mobile_App.View;

public partial class StockDetailView : ContentPage
{
    public StockDetailView(StockDetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
		plus1.CommandParameter = plus1.Text;
		plus5.CommandParameter = plus5.Text;
		plus10.CommandParameter = plus10.Text;
		moin1.CommandParameter = moin1.Text;
        moin5.CommandParameter = moin5.Text;
        moin10.CommandParameter = moin10.Text;

		List<string> list = new List<string>();
        list.AddRange(new string[] { "g", "mL", "L", "kg" });
        picker.ItemsSource = list;

        picker.SelectedItem = "mL";
    }
}