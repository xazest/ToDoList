using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly ITodoListDbContext _dbContext;
        public UpdateTodoItemCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }
            
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.IsCompleted = request.IsCompleted;
            entity.UpdatedAt = DateTime.UtcNow;
            if (request.IsCompleted)
            {
                entity.CompletedAt = DateTime.UtcNow;
            }
            else
            {
                entity.CompletedAt = null;
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
