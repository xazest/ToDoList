using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TodoList.Application.Common.Mappings;
using TodoList.Application.TodoLists.Commands.CreateTodoList;

namespace TodoList.WebAPI.Models
{
    public class CreateTodoListDto : IMapWith<CreateTodoListCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTodoListDto, CreateTodoListCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title));
        }
    }
}
