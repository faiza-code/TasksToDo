using System.ComponentModel.DataAnnotations.Schema;

namespace TasksToGo.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsCompeleted { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(taskCategory))]
        public int TaskCategoryId { get; set; }

        public TaskCategory? taskCategory { get; set; }
    }
}
