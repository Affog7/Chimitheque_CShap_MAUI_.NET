using ChimithequeLib.APisManagers;
using ChimithequeLib;
using Chimitheque_Mobile_App.View;

namespace Chimitheque_Mobile_App;

public partial class App : Application
{
    public App()
    {
        //AuthService authService = new AuthService();
        //var token = authService.GetTokenAsync("admin@chimitheque.fr", "chimitheque");
        //var httpClient = authService.httpClient;

        //var ddd = new ProductsManager().GetProductsById(1245,httpClient);
            InitializeComponent();

            MainPage = new AuthenticationView();
        
    }
}