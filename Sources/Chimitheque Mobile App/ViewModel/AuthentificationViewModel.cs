using Chimitheque_Mobile_App.View;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class AuthentificationViewModel: ObservableObject
    {
        public User user { get; set; }
        public AuthentificationViewModel()
        {
            user = new User();
        }

        [RelayCommand]
        public void Login()
        {
            AuthManager authManager = new AuthManager();
            var token = authManager.GetToken(user);
            if (!string.IsNullOrEmpty(token))
            {
                Preferences.Set("token", token);
                Application.Current.MainPage = new NavigationPage(new FlyoutView());
            }
        }

      
    }
}
