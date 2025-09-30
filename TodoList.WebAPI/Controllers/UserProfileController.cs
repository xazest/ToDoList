using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Aggregates.UserProfiles.Commands.PatchUserProfile;
using TodoList.Application.Aggregates.UserProfiles.Queries.GetUserProfile;
using TodoList.Application.Interfaces;
using TodoList.WebAPI.Services;

namespace TodoList.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly ICurrentUserService _userService;
        private readonly IMediator _mediator;
        public UserProfileController(ICurrentUserService currentUserService, IMediator mediator)
        {
            _userService = currentUserService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetUserProfileQuery
            {
                UserId = _userService.UserId
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] PatchUserProfileDto dto)
        {
            var command = new PatchUserProfileCommand
            {
                Id = dto.Id,
                UserId = _userService.UserId,
                Nickname = dto.Nickname,
                AvatarUrl = dto.AvatarUrl
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
