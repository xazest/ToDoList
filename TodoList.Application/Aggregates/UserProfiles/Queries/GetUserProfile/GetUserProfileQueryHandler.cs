using AutoMapper;
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.UserProfiles.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly ITodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserProfileQueryHandler(ITodoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserProfiles.FindAsync([request.UserId], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(UserProfile), request.UserId);
            }
            return _mapper.Map<UserProfileDto>(entity);
        }
    }
}
