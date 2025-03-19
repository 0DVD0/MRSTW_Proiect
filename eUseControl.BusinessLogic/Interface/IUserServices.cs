using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interface
{
     public interface IUserServices
     {
          bool RegisterUser(string name, string email, string password);
          string AuthUser(string name, string password);
     }
}
