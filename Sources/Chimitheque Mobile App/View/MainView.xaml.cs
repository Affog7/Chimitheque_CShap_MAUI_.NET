using Chimitheque_Mobile_App.ViewModel;

namespace Chimitheque_Mobile_App.View;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SearchProductView), typeof(SearchProductView));
        Routing.RegisterRoute(nameof(StockDetailOfflineView), typeof(StockDetailOfflineView));
    }

    private void btnScanProduct_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AjoutProduits());
    }

    private void btnRetirerProduit_Clicked(object sender, EventArgs e)
    {
        var isLogged = Preferences.Get("isConnected", false);
        if (isLogged)
        {
            Shell.Current.GoToAsync($"{nameof(SearchProductView)}");
        }
        else
        {
            Shell.Current.GoToAsync($"{nameof(StockDetailOfflineView)}");
            //Navigation.PushAsync(new StockDetailOfflineView(new StockDetailViewModel()));
        }
    }

    private void btnDeconnect_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("token", null);
        Preferences.Set("username", null);
        Preferences.Set("password", null);

        Application.Current.MainPage = new AppShell();
    }
}