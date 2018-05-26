namespace SimpleApp.Interfaces
{
    public interface IAuthService
    {
        bool IsAdmin(string password);
    }
}
