using Domain.Common.Exceptions;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Task : Entity
    {
        public string Content { get; private set; } = string.Empty;
        public bool IsCompleted { get; private set; }
        public DateTime ScheduledDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        {
            Content = content;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
            ScheduledDate = DateTime.Today.AddDays(1);
        }

        private Task() : base(Guid.NewGuid()) { }

        public static Task Create(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new DomainValidationException("Content not valid.");
            }

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

            var contentTrimmed = content.Trim();
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new DomainValidationException("Content not valid.");
            }

            if (contentTrimmed == this.Content) return;

            this.Content = contentTrimmed;
        }
    }
}
