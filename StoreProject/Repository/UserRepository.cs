using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;

namespace StoreProject.Repository
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
