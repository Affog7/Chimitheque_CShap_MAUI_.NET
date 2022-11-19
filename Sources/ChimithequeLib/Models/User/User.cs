using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Models.User
{
    public partial class User:ObservableObject
    {
        [ObservableProperty]
        private string person_email;
        
        [ObservableProperty]
        private string person_password;

    }
    
    
}
