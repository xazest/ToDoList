using AutoMapper;
using TodoList.Application.Common.Mappings;
using TodoList.Application.TodoItems.Commands.UpdateTodoItem;

namespace TodoList.WebAPI.Models
{
    public class UpdateTodoListDto :IMapWith<UpdateTodoItemCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTodoListDto, UpdateTodoItemCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.IsCompleted,
                    opt => opt.MapFrom(dto => dto.IsCompleted));
        }
    }
}
