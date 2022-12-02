using Chimitheque_Mobile_App.ViewModel;

namespace Chimitheque_Mobile_App.View;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
    }

    private void btnScanProduct_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QrCodeScane());
    }

    private void btnRetirerProduit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SearchProductView(new SearchProductViewModel()));

    }
}