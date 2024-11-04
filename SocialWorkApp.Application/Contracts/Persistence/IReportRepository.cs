using SocialWorkApp.Domain.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IReportRepository
    {
        List<Report> ListReportsByProvider(int providerId);

    }
}
