using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCHub.Domain.Dates
{
    public class YearWithReports
    {
        public ISP_Year ISP_Year { get; set; }
        public Reports.Report PBSA { get; set; }
        public Reports.Report PBSP { get; set; }
        public Reports.Report SemiAnn { get; set; }
        public Reports.Report? PPMP { get; set; }
        public Reports.Report? BCIP { get; set; }
        [DataType(DataType.Date)]
        public DateOnly NewStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly NewMeetingDate { get; set; }
    }
}
