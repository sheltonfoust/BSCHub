namespace SocialWorkApp.Application
{
    public class ProviderUser
    {
        public ProviderUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
