using AutoMapper;
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.UserProfiles.Commands.PatchUserProfile
{
    public class PatchUserProfileCommandHandler : IRequestHandler<PatchUserProfileCommand>
    {
        private readonly ITodoListDbContext _context;
        private readonly IMapper _mapper;
        public PatchUserProfileCommandHandler(ITodoListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Handle(PatchUserProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfiles.FindAsync([request.UserId], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(UserProfile), request.UserId);
            }

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
