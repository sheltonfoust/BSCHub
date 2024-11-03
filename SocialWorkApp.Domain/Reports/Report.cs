﻿using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SocialWorkApp.Domain.Reports.Status;

namespace SocialWorkApp.Domain.Reports
{
    public class Report
    {
        public Report()
        {
        }

        
        public int ReportId { get; set; }
        public ReportType Type;
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Status Status { get; set; } = Incomplete;
        public DateOnly Deadline { get; set; }
        public DateOnly? CompletedDate { get; set; }
        public DateOnly? ReviewedDate { get; set; }
        public DateOnly GetToSupervisorDueDate()
        {
            return Deadline.AddDays(-7);
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
