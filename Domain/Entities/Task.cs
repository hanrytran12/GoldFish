using Domain.Primitives;

namespace Domain.Entities
{
    public class Task : Entity
    {
        public string Content { get; private set; } = string.Empty;
        public bool IsCompleted { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Task(Guid id, string content) : base(id)
        {
            Content = content;
            IsCompleted = false;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }

        private Task() : base(Guid.NewGuid()) { }

        public static Task Create(string content)
        {
            return new Task(Guid.NewGuid(), content);
        }

        public void MarkAsCompleted()
        {
            if (IsCompleted) return;

            IsCompleted = true;
        }

        public void MarkAsUncompleted()
        {
            if (!IsCompleted) return;

            IsCompleted = false;
        }

        public void UpdateContent(string content)
        {
            if (IsCompleted) return;

            this.Content = content;
        }
    }
}
