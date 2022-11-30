using Chimitheque_Mobile_App.View;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.User;

namespace Chimitheque_Mobile_App;

public partial class App : Application
{
    public static AuthManager auth = new AuthManager();
    public App()
    {
        InitializeComponent();
        
        var token = Preferences.Get("token", null);
        //User user = new User();
        //user.Person_email = Preferences.Get("username", "admin@chimitheque.fr");
        //user.Person_password = Preferences.Get("password", "chimitheque");
        //MainPage = new AppShell();
        if (string.IsNullOrEmpty(token))
            MainPage = new AppShell();
        else
        {
            User user = new User();
            user.Person_email = Preferences.Get("username", null);
            user.Person_password = Preferences.Get("password", null);
            auth.GetToken(user);
            MainPage = new NavigationPage(new FlyoutView());
        }
    }
}