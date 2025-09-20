using TodoList.Application.Common.Mappings;
using TodoList.Domain;
using AutoMapper;

namespace TodoList.Application.TodoLists.Queries.GetListOfTodoList
{
    public class TodoListLookupDto : IMapWith<TodoListItem>
    {
        public Guid Id { get; set; }   
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoListItem, TodoListLookupDto>()
                .ForMember(todoListDto => todoListDto.Id,
                    opt => opt.MapFrom(todoList => todoList.Id))
                .ForMember(todoListDto => todoListDto.Title,
                    opt => opt.MapFrom(todoList => todoList.Title));
        }
    }
}
