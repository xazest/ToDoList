using MediatR;

namespace TodoList.Application.TodoItems.Queries.GetTodoItemList
{
    public class GetTodoItemListQuery : IRequest<TodoItemListDto>
    {
        public Guid UserId { get; set; }
    }
}
