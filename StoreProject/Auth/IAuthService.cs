namespace StoreProject.Auth
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
