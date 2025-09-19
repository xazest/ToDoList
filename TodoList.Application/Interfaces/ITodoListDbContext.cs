using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.Application.Interfaces
{
    public interface ITodoListDbContext
    {
        DbSet<TodoListItem> TodoListItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
