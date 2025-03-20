namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserActions
    {
        bool UserExists(string name, string password);
        bool UserCreate(string name, string email, string password);
        bool UserDelete(string name, string password);
    }
}
