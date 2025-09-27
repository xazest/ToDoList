
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly ITodoListDbContext _dbContext;
        public DeleteTodoItemCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoListItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof (TodoItem), request.Id);
            }
            _dbContext.TodoListItems.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
