using SocialWorkApp.Application.Services;

namespace SocialWorkApp.Application.Dashboards
{
    public class AdminDashboard
    {
        private IRepository repository;

        public AdminDashboard(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddProvider(ProviderUser providerUser)
        {
            repository.Providers.Add(providerUser);
        }

        public ICollection<ClientEntry> GetAllClients()
        {
            return repository.AllClients.ToList();
        }

        public ICollection<ProviderUser> GetProviders()
        {
            return repository.Providers.ToList();
        }
    }
}