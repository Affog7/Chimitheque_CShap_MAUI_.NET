using ChimithequeLib.APisManagers;
using ChimithequeLib;
using Chimitheque_Mobile_App.View;

namespace Chimitheque_Mobile_App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var token = Preferences.Get("token", null);

        if (string.IsNullOrEmpty(token))
            //MainPage = new AppShell();
            MainPage = new MainView();
        else
            MainPage = new NavigationPage(new MainView());
    }
}