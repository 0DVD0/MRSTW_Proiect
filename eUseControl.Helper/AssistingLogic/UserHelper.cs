using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace eUseControl.Helper.AssistingLogic
{
     public class UserHelper
     {
          public string PasswordHash(string password)
          {
              using(SHA256 sha = SHA256.Create())
               {
                    byte[] bytes = Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
               }

          }
     }
}
