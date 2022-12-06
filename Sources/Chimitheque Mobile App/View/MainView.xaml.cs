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
        Navigation.PushAsync(new AjoutProduits());
    }

    private void btnRetirerProduit_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new SearchProductView(new SearchProductViewModel()));

        Shell.Current.GoToAsync($"{nameof(SearchProductView)}");

    }

    private void btnDeconnect_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("token", null);
        Preferences.Set("username", null);
        Preferences.Set("password", null);

        Application.Current.MainPage = new AppShell();
    }
}