using AutoMapper;
using TodoList.Application.Aggregates.TodoItems.Commands.UpdateTodoItem;
using TodoList.Application.Common.Mappings;

namespace TodoList.WebAPI.Models.TodoItemDtos
{
    public class UpdateTodoItemDto :IMapWith<UpdateTodoItemCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTodoItemDto, UpdateTodoItemCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.IsCompleted,
                    opt => opt.MapFrom(dto => dto.IsCompleted));
        }
    }
}
