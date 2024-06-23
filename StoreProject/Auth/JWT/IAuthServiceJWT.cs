namespace StoreProject.Auth.JWT
{
    public interface IAuthServiceJWT
    {
        Task<UserJWT> AuthenticationAsync(string name, string password);
    }
}
