using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektinis_darbas_akademine_is.Classes
{
    internal class CheckLogin
    {
        public static bool Check(string username, string password,string Checkusername, string Checkpassword)
        {
            if (username == Checkusername && password == Checkpassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
