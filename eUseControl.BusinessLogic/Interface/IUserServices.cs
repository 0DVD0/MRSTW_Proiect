namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserServices
    {
        bool RegisterUser(string name, string email, string password);
        string AuthUser(string name, string password);
    }
}
