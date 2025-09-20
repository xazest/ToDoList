using TodoList.Application.Common.Mappings;
using TodoList.Domain;

namespace TodoList.Application.TodoLists.Queries.GetTodoList
{
    public class TodoListDto : IMapWith<TodoListItem>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<TodoListItem, TodoListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(todo => todo.Id))
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(todo => todo.Title))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(todo => todo.Description))
                .ForMember(dto => dto.IsCompleted,
                    opt => opt.MapFrom(todo => todo.IsCompleted))
                .ForMember(dto => dto.CreatedAt,
                    opt => opt.MapFrom(todo => todo.CreatedAt))
                .ForMember(dto => dto.UpdatedAt,
                    opt => opt.MapFrom(todo => todo.UpdatedAt))
                .ForMember(dto => dto.CompletedAt,
                    opt => opt.MapFrom(todo => todo.CompletedAt));
        }
    }
}
