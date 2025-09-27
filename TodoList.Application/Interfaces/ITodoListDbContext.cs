using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.Application.Interfaces
{
    public interface ITodoListDbContext
    {
        DbSet<TodoItem> TodoListItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
