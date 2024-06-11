﻿using StoreProject.DB.Models;
using StoreProject.Repository.Generic;

namespace StoreProject.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
