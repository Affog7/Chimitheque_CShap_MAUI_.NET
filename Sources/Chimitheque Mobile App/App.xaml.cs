using Chimitheque_Mobile_App.View;
using Chimitheque_Mobile_App.View.UC;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.User;
using ChimithequeLib.ViewModel.Users;

namespace Chimitheque_Mobile_App;

public partial class App : Application
{
    public static AuthManager auth = new AuthManager();
    public App()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(RecapitulatifsTransaction), typeof(RecapitulatifsTransaction));

        var token = Preferences.Get("token", null);
        Preferences.Set("isConnected", false);
        if (string.IsNullOrEmpty(token))
            MainPage = new AppShell();
        else
        {
            /* Getting the username and password from the preferences and then it is getting the token
            from the API. */
            UserViewModel userVM = new UserViewModel();
            userVM.Person_email = Preferences.Get("username", null);
            userVM.Person_password = Preferences.Get("password", null);

            //Verifier si le portable est connecté à internet ou non
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //Getting the token from the API
                auth.GetToken(userVM.user);
                Preferences.Set("isConnected", true);
                MainPage = new FlyoutView();
            }
            else
            {
                Preferences.Set("isConnected", false);
                //Getting the token from the local storage
                MainPage = new FlyoutView();
            }
        }
    }
}