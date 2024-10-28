﻿using SocialWorkApp.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IDateRepository
    {
        public List<ISP_Year>? GetISPYears(int clientId);
        public void AddYear(int clientId, DateOnly startDate);

    }
}
