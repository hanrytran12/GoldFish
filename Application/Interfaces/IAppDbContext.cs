using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
    }
}
