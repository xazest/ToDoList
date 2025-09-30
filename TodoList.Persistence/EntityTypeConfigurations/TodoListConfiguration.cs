using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain;

namespace TodoList.Persistence.EntityTypeConfigurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t=> t.Id).IsUnique();
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).HasMaxLength(1000);
            builder.Property(t => t.IsCompleted).IsRequired().HasDefaultValue(false);
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt);
            builder.Property(t => t.CompletedAt);
        }
    }
}
