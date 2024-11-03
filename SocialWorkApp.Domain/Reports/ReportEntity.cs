using SocialWorkApp.Domain.Clients;
using static SocialWorkApp.Domain.Reports.Status;

namespace SocialWorkApp.Domain.Reports
{
    public class ReportEntity
    {
        public ReportEntity()
        {
        }

        
        public int ReportEntityId { get; set; }
        public DateOnly? CompletedDate { get; set; }
        public DateOnly? ReviewedDate { get; set; }
        public ReportType Type { get; set; }

        public int ISP_YearId { get; set; }
        public ISP_Year ISP_Year { get; set; }

        


        
        
    }

    
}
