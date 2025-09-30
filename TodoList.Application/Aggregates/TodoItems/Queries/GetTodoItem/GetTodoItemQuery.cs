
using MediatR;

namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
