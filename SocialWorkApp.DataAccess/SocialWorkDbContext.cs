using Microsoft.EntityFrameworkCore;
using BSCHub.Domain.Clients;
using BSCHub.Domain.Users;


namespace BSCHub.DataAccess
{
    public class SocialWorkDbContext : DbContext
    {
        public SocialWorkDbContext(
            DbContextOptions<SocialWorkDbContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<ISP_Year> ISP_Years => Set<ISP_Year>();
        public DbSet<User> Users => Set<User>();
    }
}
