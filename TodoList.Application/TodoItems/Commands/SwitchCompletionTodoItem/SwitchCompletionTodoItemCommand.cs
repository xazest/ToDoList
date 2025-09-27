using MediatR;

namespace TodoList.Application.TodoItems.Commands.SwitchCompletionTodoItem
{
    public class SwitchCompletionTodoItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
