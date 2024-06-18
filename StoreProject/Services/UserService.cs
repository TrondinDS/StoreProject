using StoreProject.DB.Models;
using StoreProject.Repository.Interfaces;
using StoreProject.Services.Interfaces;

namespace StoreProject.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task AddAsync(User customer)
        {
            await userRepository.AddAsync(customer);
            await userRepository.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user != null)
            { 
                userRepository.Delete(user);
                await userRepository.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User customer)
        {
            userRepository.Update(customer);
            await userRepository.SaveChangesAsync();

        }
    }
}
