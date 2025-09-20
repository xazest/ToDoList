using MediatR;

namespace TodoList.Application.TodoLists.Queries.GetListOfTodoList
{
    public class GetListOfTodoListQuery : IRequest<ListOfTodoListDto>
    {
        public Guid UserId { get; set; }
    }
}
