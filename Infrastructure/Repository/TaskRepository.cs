using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTask(Domain.Entities.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Domain.Entities.Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public async Task<List<Domain.Entities.Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Domain.Entities.Task?> GetTaskByIdAsync(Guid id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void UpdateTask(Domain.Entities.Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
