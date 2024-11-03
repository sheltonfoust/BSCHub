using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWorkApp.Domain.Reports;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SocialWorkApp.Application
{
    public static class DateHelper
    {
        public static DateOnly GetToday()   
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
            return DateOnly.FromDateTime(localTime);
        }

        //public static bool IsLate(this Report report, bool isIndependent)
        //{
        //    if (report.Status == Status.Accepted)
        //        return false;
        //    if (isIndependent)
        //        return DateHelper.GetToday() > report.Deadline;
        //    return DateHelper.GetToday() > report.GetToSupervisorDueDate();
        //}

    }
}
