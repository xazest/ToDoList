using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandHandler
    {
        private readonly ITodoListDbContext _dbContext;
        public CreateTodoListCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoListItem
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false,
                UpdatedAt = null,
                CompletedAt = null

            };
            await _dbContext.TodoListItems.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
