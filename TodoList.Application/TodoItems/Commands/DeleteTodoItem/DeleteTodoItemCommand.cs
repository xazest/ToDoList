using MediatR;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand: IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
