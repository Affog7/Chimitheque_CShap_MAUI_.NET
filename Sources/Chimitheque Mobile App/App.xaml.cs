using Chimitheque_Mobile_App.View;

namespace Chimitheque_Mobile_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AuthenticationView();
        }
    }
}