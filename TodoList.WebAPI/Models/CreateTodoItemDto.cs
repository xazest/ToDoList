using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TodoList.Application.Common.Mappings;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;

namespace TodoList.WebAPI.Models
{
    public class CreateTodoItemDto : IMapWith<CreateTodoItemCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTodoItemDto, CreateTodoItemCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description,
                    opt => opt.MapFrom(dto => dto.Description));
        }
    }
}
