using BSCHub.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCHub.Application.Contracts.Persistence
{
    public interface IDateRepository
    {
        public List<ISP_Year>? GetISPYears(int clientId);
        public void AddYear(int clientId, DateOnly startDate);
        public void DeleteYear(int yearId);
        void UpdateYear(DateOnly newYearStart, int ISP_YearId);
        void UpdateMeetingDate(DateOnly meetingDate, int ISP_YearId);
    }
}
