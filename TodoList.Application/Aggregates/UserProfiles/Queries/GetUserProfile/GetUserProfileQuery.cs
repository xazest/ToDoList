using MediatR;

namespace TodoList.Application.Aggregates.UserProfiles.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<UserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
