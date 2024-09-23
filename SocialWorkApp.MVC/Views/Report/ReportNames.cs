using SocialWorkApp.Domain.Reports;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.MVC.Views.Report
{
    public static class ReportNames
    {
        private static readonly Dictionary<ReportType,string> names = new Dictionary<ReportType,string>
        {

            { SemiAnn, "Semi-Annual" },
   
        };
        public static string GetName(ReportType type)
        {
            if (names.ContainsKey(type)) 
                return names[type];
            return type.ToString();
        }

    }
}
