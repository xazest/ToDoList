using MediatR;

namespace TodoList.Application.Aggregates.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
