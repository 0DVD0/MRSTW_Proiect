namespace eUseControl.BusinessLogic.Interface
{
    public interface IUserActions
    {
        bool UserExists(string name, string password);
        void UserCreate(string name, string email, string password);
        void UserDelete(string name, string password);
    }
}
