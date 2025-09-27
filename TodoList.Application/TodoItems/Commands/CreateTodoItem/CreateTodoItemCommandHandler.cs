using MediatR;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly ITodoListDbContext _dbContext;
        public CreateTodoItemCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
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
