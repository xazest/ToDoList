
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly ITodoListDbContext _dbContext;
        public DeleteTodoListCommandHandler(ITodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoListItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof (TodoListItem), request.Id);
            }
            _dbContext.TodoListItems.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
