using MediatR;

namespace TodoList.Application.Aggregates.TodoItems.Commands.SwitchCompletionTodoItem
{
    public class SwitchCompletionTodoItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
