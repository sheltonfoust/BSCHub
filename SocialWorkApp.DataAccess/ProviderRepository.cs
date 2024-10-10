﻿using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.DataAccess
{
    public class ProviderRepository : IProviderRepository
    {

        private readonly SocialWorkDbContext dbContext;
        public ProviderRepository(SocialWorkDbContext socialWorkDbContext)
        {
            this.dbContext = socialWorkDbContext;
        }
        public IReadOnlyCollection<Provider> ListProviders()
        {
            return dbContext.Providers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
        }
    }
}
