using TodoList.Application.Common.Mappings;
using AutoMapper;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.UserProfiles.Commands.PatchUserProfile
{
    public class PatchUserProfileDto : IMapWith<UserProfile>
    {
        public string? Id { get; set; }
        public string? Nickname { get; set; }
        public string? AvatarUrl { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchUserProfileCommand, UserProfile>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
