using Chimitheque_Mobile_App.APisManagers;

namespace Chimitheque_Mobile_App
{
    public partial class App : Application
    {
        public App()
        {
            var ddd = new ProductsManager().GetProductsById(5);

            Console.WriteLine(ddd);

            //InitializeComponent();

           // MainPage = new AppShell();
        }
    }
}