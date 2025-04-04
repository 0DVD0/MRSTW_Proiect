using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserServices
    {
        bool RegisterUser(User user);
        bool LoginUser(User user);
        bool RemoveUser(string name, string email);
     }
}
