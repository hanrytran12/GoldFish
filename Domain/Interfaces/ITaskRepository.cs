namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Domain.Entities.Task>> GetAllTasksAsync();
        Task<Domain.Entities.Task?> GetTaskByIdAsync(Guid id);
        Task AddTaskAsync(Domain.Entities.Task task);
        Task UpdateTaskAsync(Domain.Entities.Task task);
        Task DeleteTaskAsync(Domain.Entities.Task task);
    }
}
