using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interface
{
     public interface IUserActions
     {
          bool UserExists(string name, string password);
          bool UserCreate(string name, string email, string password);
          bool UserDelete(string name, string password);
     }
}
