using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Models.User
{
    public class User
    {
        private string person_email;
        
        private string person_password;

        public string Person_email
        {
            get => person_email;
            set => person_email = value;
        }

        public string Person_password
        {
            get => person_password;
            set => person_password = value;
        }

    }
    
    
}
