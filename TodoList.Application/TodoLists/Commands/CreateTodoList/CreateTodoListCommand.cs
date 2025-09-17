using MediatR;

namespace TodoList.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
