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
        //User user = new User();
        //user.Person_email = Preferences.Get("username", "admin@chimitheque.fr");
        //user.Person_password = Preferences.Get("password", "chimitheque");
        //MainPage = new AppShell();


        /* Checking if the token is empty or not. If it is empty, it will go to the AppShell page. If
        it is not empty, it will go to the FlyoutView page. */
        if (string.IsNullOrEmpty(token))
            MainPage = new AppShell();
       // MainPage = new ProductDetailsUc();
        else
        {
            /* Getting the username and password from the preferences and then it is getting the token
            from the API. */
            UserViewModel userVM = new UserViewModel();
            userVM.Person_email = Preferences.Get("username", null);
            userVM.Person_password = Preferences.Get("password", null);
            auth.GetToken(userVM.user);
            MainPage = new FlyoutView();
        }
    }
}