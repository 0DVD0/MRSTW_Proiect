using eUseControl.BusinessLogic.Interface;

namespace eUseControl.BusinessLogic.Core
{
    public class UserServices : IUserServices
    {
        private readonly IUserActions _userAction;
        private readonly string _token = "Thisisatoken";

        public UserServices(IUserActions userAction)
        {
            _userAction = userAction;
        }

        public bool RegisterUser(string name, string email, string password)
        {
            if (_userAction.UserExists(name, password))
            {
                return false;
            }
            return _userAction.UserCreate(name, email, password);
        }

        public string AuthUser(string name, string password)
        {
            return null;
        }
    }
}
