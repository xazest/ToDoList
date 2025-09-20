using System.Security.Claims;
using TodoList.Application.Interfaces;

namespace TodoList.WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                if (!IsAuthenticated)
                    throw new UnauthorizedAccessException("User is not authenticated.");

                var claim = _httpContextAccessor.HttpContext?.User?
                            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(claim, out var guid))
                    return guid;

                throw new InvalidOperationException("User ID claim is missing or invalid.");
            }
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?
                                       .Identity?.IsAuthenticated ?? false;
    }
}
