using TodoList.Application.Common.Mappings;
using TodoList.Domain;
using AutoMapper;

namespace TodoList.Application.TodoItems.Queries.GetTodoItemList
{
    public class TodoItemLookupDto : IMapWith<TodoItem>
    {
        public Guid Id { get; set; }   
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemLookupDto>()
                .ForMember(todoListDto => todoListDto.Id,
                    opt => opt.MapFrom(todoList => todoList.Id))
                .ForMember(todoListDto => todoListDto.Title,
                    opt => opt.MapFrom(todoList => todoList.Title));
        }
    }
}
