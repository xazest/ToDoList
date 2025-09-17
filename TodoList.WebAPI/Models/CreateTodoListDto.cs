using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TodoList.WebAPI.Models
{
    public class CreateTodoListDto : IMapWith<CreateTodoListCommand>
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTodoListDto, CreateTodoListCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title));
        }
    }
}
