using TodoList.Application.Common.Mappings;
using TodoList.Domain;
using AutoMapper;

namespace TodoList.Application.Aggregates.UserProfiles.Queries.GetUserProfile
{
    public class UserProfileDto : IMapWith<UserProfile>
    {
        public string? Id { get; set; }
        public Guid UserId { get; set; }
        public string? Nickname { get; set; }
        public string? AvatarUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(userProfile => userProfile.Id))
                .ForMember(dto => dto.UserId,
                    opt => opt.MapFrom(userProfile => userProfile.UserId))
                .ForMember(dto => dto.Nickname,
                    opt => opt.MapFrom(userProfile => userProfile.Nickname))
                .ForMember(dto => dto.AvatarUrl,
                    opt => opt.MapFrom(userProfile => userProfile.AvatarUrl));
        }
    }
}
