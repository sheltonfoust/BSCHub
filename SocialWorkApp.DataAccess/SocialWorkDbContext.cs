using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;


namespace SocialWorkApp.DataAccess
{
    public class SocialWorkDbContext : DbContext
    {
        public SocialWorkDbContext(
            DbContextOptions<SocialWorkDbContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Provider> Providers => Set<Provider>();
        public DbSet<ISP_Year> ISP_Years => Set<ISP_Year>();
        public DbSet<User> Users => Set<User>();
    }
}
