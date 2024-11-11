using BSCHub.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCHub.Application
{
    public static class ReportHelper
    {
        public static DateOnly? GetDeadline(ReportType type, ISP_Year year, bool isSevere)
        {
            switch (type)
            {
                case ReportType.PBSA:
                    return year.MeetingDate?.AddDays(-14);
                case ReportType.PBSP:
                    return isSevere ? year.MeetingDate?.AddDays(14) : year.StartDate;
                case ReportType.SemiAnn:
                    return year.StartDate.AddDays(190);
                default:
                    return year.StartDate;
            }
        }
        public static DateOnly? GetDueBySupervisor(ReportType type, ISP_Year year, bool isSevere)
        {
            return GetDeadline(type, year, isSevere)?.AddDays(-7);
        }

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
}
