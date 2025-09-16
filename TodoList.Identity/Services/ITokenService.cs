using TodoList.Identity.Models;

namespace TodoList.Identity.Services
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
