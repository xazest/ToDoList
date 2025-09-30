namespace TodoList.Domain
{
    public class UserProfile
    {
        public required string Id { get; set; }
        public Guid UserId { get; set; }
        public required string Nickname { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
