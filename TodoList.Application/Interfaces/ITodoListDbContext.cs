using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.Application.Interfaces
{
    public interface ITodoListDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
