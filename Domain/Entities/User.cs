using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public class User : AggregrateRoot
    {
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public UserRole Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private readonly List<Task> _tasks = new();
        public IReadOnlyCollection<Task> Tasks => _tasks.AsReadOnly();

        public User(Guid id, string username, string password, string email, string phone, UserRole role, DateTime createdAt)
            : base(id)
        {
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            Role = role;
            CreatedAt = createdAt;
        }

        private User() : base(Guid.NewGuid()) { }
    }
}
