using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoItems.Commands.SwitchCompletionTodoItem
{
    public class SwitchCompletionTodoItemCommandHandler : IRequestHandler<SwitchCompletionTodoItemCommand>
    {
        private readonly ITodoListDbContext _dbContext;
        public SwitchCompletionTodoItemCommandHandler(ITodoListDbContext dbContext) 
        { 
           _dbContext = dbContext;
        }
        public async Task Handle(SwitchCompletionTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.IsCompleted ^= true;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
