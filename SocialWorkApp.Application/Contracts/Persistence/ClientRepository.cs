using SocialWorkApp.Domain.Clients;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<IReadOnlyList<Client>> ListByProvider(int providerId);
    }
}
