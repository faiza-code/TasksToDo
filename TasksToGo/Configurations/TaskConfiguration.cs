using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksToGo.Models;

namespace TasksToGo.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(t => t.Name)
                 .IsRequired()
                 .HasMaxLength(70);
            
            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(t => t.Deadline)
                .IsRequired();

            builder.Property(t => t.IsCompeleted)
                .HasDefaultValue(false)
                .IsRequired(false);

        }
    }
}
