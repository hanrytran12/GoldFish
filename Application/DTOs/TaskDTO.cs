namespace Application.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
