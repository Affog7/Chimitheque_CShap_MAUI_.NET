using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChimithequeLib.Models.User;

namespace ChimithequeLib.ViewModel.Users
{
    public partial class UserViewModel:ObservableObject
    {
        public User user { get; set; }
        public UserViewModel()
        {
            user = new User();
        }

        public string Person_email
        {
            get => user.Person_email;
            set => SetProperty(user.Person_email, value, user, (u, v) => u.Person_email = v);
        }

        public string Person_password
        {
            get => user.Person_password;
            set => SetProperty(user.Person_password, value, user, (u, v) => u.Person_password = v);
        }
    }

}
