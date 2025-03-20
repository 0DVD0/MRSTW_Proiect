namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserServices
    {
        void RegisterUser(string name, string email, string password);
        string AuthUser(string name, string password);
    }
}
