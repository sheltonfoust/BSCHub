using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Client Client { get; set; }
        public Provider Provider { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateMarkedAsComplete { get; set; }
        public bool OnTime { get; set; }
    }

    public enum Category
    { 
        PBSA,
        PBSP,
        BCIP,
        PPMP,
        RMP
    }

    public enum Status
    {
        Upcoming,
        InReview,
        Reviewed
    }

}
