using Microsoft.EntityFrameworkCore;
using TodoList.Application.Interfaces;
using TodoList.Domain;
using TodoList.Persistence.EntityTypeConfigurations;

namespace TodoList.Persistence
{
    public class TodoListDbContext : DbContext, ITodoListDbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoListConfiguration());
            builder.ApplyConfiguration(new UserProfileConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
