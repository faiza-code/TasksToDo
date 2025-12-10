using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksToGo.Models;

namespace TasksToGo.Configurations
{
    public class TaskCategoryConfiguration : IEntityTypeConfiguration<TaskCategory>
    {
        public void Configure(EntityTypeBuilder<TaskCategory> builder)
        {
            builder.Property(c => c.CreatedAt)
                 .HasDefaultValue(DateTime.UtcNow);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
                
        }
    }
}
