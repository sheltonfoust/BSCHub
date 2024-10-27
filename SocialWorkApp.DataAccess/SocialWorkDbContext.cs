using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;


namespace SocialWorkApp.DataAccess
{
    public class SocialWorkDbContext : DbContext
    {
        public SocialWorkDbContext(
            DbContextOptions<SocialWorkDbContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Report> Reports => Set<Report>();
        public DbSet<Provider> Providers => Set<Provider>();
        public DbSet<ISP_Calendar> Calendars => Set<ISP_Calendar>();
        public DbSet<ISP_YearStartDate> ISP_YearStartDates => Set<ISP_YearStartDate>();
        public DbSet<ISP_MeetingDate> ISP_MeetingDates => Set<ISP_MeetingDate>();
    }
}
