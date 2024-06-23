
namespace StoreProject.Auth.JWT
{
    public class AuthServiceJWT : IAuthServiceJWT
    {
        public AuthServiceJWT() 
        {
        }

        public Task<UserJWT> AuthenticationAsync(string name, string password)
        {
            var ListUser = new List<UserJWT>()
            {
                new UserJWT{ UserName = "Admin", Password = "Admin", Role = "Admin" },
                new UserJWT{ UserName = "User", Password = "User", Role = "User" }
            };
            return Task.FromResult(ListUser.SingleOrDefault(x => x.UserName == name && x.Password == password));
        }
    }
}
