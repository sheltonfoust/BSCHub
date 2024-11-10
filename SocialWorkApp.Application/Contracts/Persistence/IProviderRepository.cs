using SocialWorkApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IProviderRepository
    {
        List<Provider> ListProviders();
        Provider? GetProvider(int id);
    }
}
