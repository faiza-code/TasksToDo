using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksToGo.Models.AuthModel;

namespace TasksToGo.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The Name Should be Less than 10 Characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsCompeleted { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(taskCategory))]
        public int TaskCategoryId { get; set; }

        public TaskCategory? taskCategory { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
       
    }
}
