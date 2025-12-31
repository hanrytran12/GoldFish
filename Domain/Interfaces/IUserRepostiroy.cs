using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepostiroy
    {
        Task<List<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        System.Threading.Tasks.Task AddUserAsync(User user);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(User user);
    }
}
