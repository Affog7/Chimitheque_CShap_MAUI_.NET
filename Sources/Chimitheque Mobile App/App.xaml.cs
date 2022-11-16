using ChimithequeLib.APisManagers;
using ChimithequeLib;

namespace Chimitheque_Mobile_App;

public partial class App : Application
{
    public App()
    {
        AuthService authService = new AuthService();
        var token = authService.GetTokenAsync("admin@chimitheque.fr", "chimitheque");
        var httpClient = authService.httpClient;

        var ddd = new Product_Storage_LocationManager().GetStorageServiceById(1,httpClient);
        //InitializeComponent();

        // MainPage = new AppShell();
    }
}