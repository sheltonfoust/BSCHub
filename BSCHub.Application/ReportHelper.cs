using BSCHub.Domain.Dates;
using BSCHub.Domain.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCHub.Application
{
    public static class ReportHelper
    {


        public static Dictionary<ReportType, Report> GetYearReports(ISP_Year year)
        {
            var reports = new Dictionary<ReportType, Report>();
            reports[ReportType.PBSA] = GetReportFrom(year, ReportType.PBSA);
            reports[ReportType.PBSP] = GetReportFrom(year, ReportType.PBSP);
            reports[ReportType.SemiAnn] = GetReportFrom(year, ReportType.SemiAnn);
            if (year.HasBCIP)
            {
                reports[ReportType.BCIP] = GetReportFrom(year, ReportType.BCIP);
            }
            if (year.HasPPMP)
            {
                reports[ReportType.PPMP] = GetReportFrom(year, ReportType.PPMP);
            }
            return reports;
        }
        private static Report GetReportFrom(ISP_Year year, ReportType type)
        {
            return new Report
            {
                ClientName = year.Client.GetName(),
                Type = type,
                Deadline = GetDeadline(year, type, year.IsSevere),
                DueToSupervisorBy = year.Client.User == null ? null : year.Client.User.IsIndependent ? null : GetDueBySupervisor(type, year, year.IsSevere),
                ISP_YearId = year.ISP_YearId,
                IsCompleted = GetCompletedDate(year, type) != null,
                IsReviewed = GetReviewedDate(year, type) != null,
            };
        }
        public static DateOnly? GetDeadline(ISP_Year year, ReportType type, bool isSevere)
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
        public static DateOnly? GetCompletedDate(ISP_Year year, ReportType type)
        {
            switch (type)
            {
                case ReportType.PBSA:
                    return year.PBSA_CompletedDate;
                case ReportType.PBSP:
                    return year.PBSP_CompletedDate;
                case ReportType.SemiAnn:
                    return year.PBSP_CompletedDate;
                case ReportType.BCIP:
                    return year.BCIP_CompletedDate;
                case ReportType.PPMP:
                    return year.PPMP_CompletedDate;
                default:
                    return null;
            }
        }

        public static DateOnly? GetReviewedDate(ISP_Year year, ReportType type)
        {
            switch (type)
            {
                case ReportType.PBSA:
                    return year.PBSA_ReviewedDate;
                case ReportType.PBSP:
                    return year.PBSP_ReviewedDate;
                case ReportType.SemiAnn:
                    return year.SemiAnnReviewedDate;
                case ReportType.BCIP:
                    return year.BCIP_ReviewedDate;
                case ReportType.PPMP:
                    return year.PPMP_ReviewedDate;
                default:
                    return null;
            }
        }




        public static DateOnly? GetDueBySupervisor(ReportType type, ISP_Year year, bool isSevere)
        {
            return GetDeadline(year, type, isSevere)?.AddDays(-7);
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
