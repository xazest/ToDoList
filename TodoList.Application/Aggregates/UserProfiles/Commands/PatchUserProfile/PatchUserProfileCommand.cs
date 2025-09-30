using MediatR;

namespace TodoList.Application.Aggregates.UserProfiles.Commands.PatchUserProfile
{
    public class PatchUserProfileCommand : IRequest
    {
        public string? Id { get; set; }
        public Guid UserId { get; set; }
        public string? Nickname { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
