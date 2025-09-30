using MediatR;

namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItemList
{
    public class GetTodoItemListQuery : IRequest<TodoItemListDto>
    {
        public Guid UserId { get; set; }
    }
}
