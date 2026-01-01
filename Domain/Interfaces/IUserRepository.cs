using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        System.Threading.Tasks.Task AddUserAsync(User user);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(User user);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByPhoneAsync(string phone);
    }
}
