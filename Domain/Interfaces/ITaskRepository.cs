namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Domain.Entities.Task>> GetAllTasksAsync();
        Task<Domain.Entities.Task?> GetTaskByIdAsync(Guid id);
        void AddTask(Domain.Entities.Task task);
        void UpdateTask(Domain.Entities.Task task);
        void DeleteTask(Domain.Entities.Task task);
    }
}
