using MediatR;

namespace TodoList.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommand: IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
