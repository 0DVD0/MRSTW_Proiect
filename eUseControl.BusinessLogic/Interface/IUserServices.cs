using eUseControl.Domain.Entities.User;
using System.CodeDom;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserServices
    {
        bool RegisterUser(User user);
        User LoginUser(User user);
        bool RemoveUser(string name, string email);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        UserMembership GetUserMembershipById(int id);
        int? SaveUserMembership(UserMembership userMembership);
        bool UpdateUserMembership(int? userMembershipId, int? userId);
        bool UpdateUserPassword(User user, string newPassword);
        byte[] GenerateQrCode(string qrText);
        bool RemoveUserMembership(int id);
        int GetTotalUsers();
        int GetTotalActiveMemberships();
        List<User> GetAllUsers();
        bool RemoveUserById(int id);
     }
}
