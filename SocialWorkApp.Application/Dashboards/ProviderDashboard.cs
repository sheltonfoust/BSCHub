using SocialWorkApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Dashboards
{
    public class ProviderDashboard
    {
        public IRepository repository;
        public ProviderDashboard(IRepository repository)
        {
            this.repository = repository;
        }

        public List<ReportEntry> GetAllReports()
        {
            throw new NotImplementedException();
        }
    }
}
