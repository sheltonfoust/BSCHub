using BSCHub.Domain.Dates;

namespace BSCHub.Domain.Reports
{
    public class Report
    {
        public string ClientName { get; set; } = string.Empty;
        public DateOnly? Deadline { get; set; }
        public DateOnly? DueToSupervisorBy { get; set; }
        public ReportType Type { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsReviewed { get; set; }
        public int ISP_YearId { get; set; }
        
    }
}
