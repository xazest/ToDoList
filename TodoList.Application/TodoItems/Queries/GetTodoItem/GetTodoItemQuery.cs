
using MediatR;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
