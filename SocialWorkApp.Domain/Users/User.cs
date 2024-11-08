namespace SocialWorkApp.Domain.Users
{
    public class User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool IsProvider { get; set; }
        public bool IsAdmin { get; set; }
        public int? ProviderId { get; set; }
        public Provider? Provider { get; set; }

    }
}
