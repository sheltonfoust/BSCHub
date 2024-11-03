using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain.Reports
{
    public class Report
    {
        public bool IsLate { get; set; }
        public bool IsComplete { get; set; }
        public bool IsReviewed { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public int ISP_YearId { get; set; }
        public ReportType Type { get; set; }
        public DateOnly Deadline { get; set; }
        public DateOnly? DueToSupervisorBy { get; set; }



        private static readonly Dictionary<ReportType, string> names = new Dictionary<ReportType, string>
            {
                { ReportType.SemiAnn, "Semi-Annual" },
            };
        public static string GetName(ReportType type)
        {
            if (names.ContainsKey(type))
                return names[type];
            return type.ToString();
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
        Incomplete,
        Pending,
        Accepted
    }

}

