using Chimitheque_Mobile_App.View;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.User;
using ChimithequeLib.ViewModel.Users;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class AuthentificationViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isLogged = false;
        public UserViewModel user { get; set; }
        public AuthentificationViewModel()
        {
            user = new UserViewModel();
        }


        /// <summary>
        /// The function is called when the user clicks on the login button. It checks if the user's
        /// credentials are correct and if they are, it saves the token in the preferences and navigates
        /// to the main page
        /// </summary>
        [RelayCommand]
        public void Login()
        {
            AuthManager authManager = new AuthManager();
            var token = authManager.GetToken(user.user);
            if (!string.IsNullOrEmpty(token))
            {
                Preferences.Set("token", token);
                Preferences.Set("username", user.Person_email);
                Preferences.Set("password", user.Person_password);
                App.auth = authManager;
                //IsLogged = true;
                Application.Current.MainPage = new NavigationPage(new FlyoutView());

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Erreur", "Identifiant ou mot de passe incorrect", "OK");
            }
        }
    }
}
