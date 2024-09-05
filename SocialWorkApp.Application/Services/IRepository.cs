namespace SocialWorkApp.Application.Services
{
    public interface IRepository
    {
        public ICollection<ProviderUser> Providers { get; }
        public ICollection<ClientEntry> AllClients { get; }
    }
}
