using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TasksToGo.Models.AuthModel
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; internal set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; internal set; }
        public IEnumerable<TodoTask> todoTasks { get; set; } = new HashSet<TodoTask>();

    }
}
