using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektinis_darbas_akademine_is.Interface
{
    internal interface ILoginValidation
    {
        bool ValidateLogin(string username, string password);
    }
}
