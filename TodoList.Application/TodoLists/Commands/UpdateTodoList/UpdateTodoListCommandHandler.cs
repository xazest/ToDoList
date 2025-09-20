using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly ITodoListDbContext _dbContext;
        public UpdateTodoListCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoListItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoListItem), request.Id);
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
