using SocialWorkApp.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialWorkApp.Domain.Reports.Status;

namespace SocialWorkApp.Domain.Reports
{
    public class Report
    {
        public int ReportId { get; set; }
        public Report(ReportType type, DateOnly dueDate, Client client)
        {
            Client = client;
            Type = type;
            DueDate = dueDate;
        }
        public readonly ReportType Type;

        public Client Client { get; set; }
        public DateOnly DueDate { get; set; }
        public Status Status { get; private set; } = Upcoming;
        public DateOnly? ReviewedDate { get; private set; }

        public void MarkAsComplete()
        {
            if (Status == Upcoming)
            {
                Status = InReview;
            }

        }

        public void Review(DateOnly reviewedDate)
        {
            Status = Reviewed;
            ReviewedDate = reviewedDate;
        }
    }

    public enum ReportType
    {
        PBSA,
        PBSP,
        SemiAnn,
        BCIP,
        PPMP,
    }
    
    

    public enum Status
    {
        Upcoming,
        InReview,
        Reviewed
    }
}
