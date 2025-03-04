namespace AuthService.Domain.Domain
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
    }
}