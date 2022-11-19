using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App
{
    public partial class Util : ObservableObject
    {
        [ObservableProperty]
        private string person_email;

        [ObservableProperty]
        private string person_password;
    }
}
