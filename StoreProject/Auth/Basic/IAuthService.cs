﻿namespace StoreProject.Auth.Basic
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
