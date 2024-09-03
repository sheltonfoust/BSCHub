using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Core.Reports
{
    public class Report
    {
        public DateOnly DueDate { get; set; }
    }

    public enum ReportType
    {
        PBSA,
        PBSP,
        BCIP,
        PPMP,
        RMP
    }
}
