using ChimithequeLib.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.APisManagers
{
    public class AuthManager
    {
        public AuthService service = new AuthService();
        /// <summary>
        /// It gets a token from the server
        /// </summary>
        /// <param name="User"></param>
        /// <returns>
        /// A string
        /// </returns>
        public string? GetToken(User user)
        {
            var token=service.GetTokenAsync(user.Person_email, user.Person_password);
            return token.Result;
        }
    }
}
