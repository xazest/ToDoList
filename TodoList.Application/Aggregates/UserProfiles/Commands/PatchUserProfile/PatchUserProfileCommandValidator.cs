using FluentValidation;

namespace TodoList.Application.Aggregates.UserProfiles.Commands.PatchUserProfile
{
    public class PatchUserProfileCommandValidator : AbstractValidator<PatchUserProfileCommand>
    {
        public PatchUserProfileCommandValidator() 
        { 
            RuleFor(x => x.Nickname)
                .MaximumLength(24).WithMessage("Nickname must not exceed 24 characters.");
            RuleFor(x=>x.Id)
                .MaximumLength(36).WithMessage("Id must not exceed 36 characters.");
        }
    }
}
