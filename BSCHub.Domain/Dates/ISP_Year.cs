using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCHub.Domain.Clients;

namespace BSCHub.Domain.Dates
{
    public class ISP_Year
    {
        [Key]
        public int ISP_YearId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? MeetingDate { get; set; } = null;

        public bool HasBCIP { get; set; }
        public bool HasPPMP { get; set; }
        public bool IsSevere { get; set; }

        public DateOnly? PBSA_CompletedDate { get; set; }
        public DateOnly? PBSA_ReviewedDate { get; set; }

        public DateOnly? PBSP_CompletedDate { get; set; }
        public DateOnly? PBSP_ReviewedDate { get; set; }

        public DateOnly? SemiAnnCompletedDate { get; set; }
        public DateOnly? SemiAnnReviewedDate { get; set; }

        public DateOnly? BCIP_CompletedDate { get; set; }
        public DateOnly? BCIP_ReviewedDate { get; set; }

        public DateOnly? PPMP_CompletedDate { get; set; }
        public DateOnly? PPMP_ReviewedDate { get; set; }


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
