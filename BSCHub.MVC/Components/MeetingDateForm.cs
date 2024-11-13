using BSCHub.Application;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BSCHub.MVC.Components
{
    public class MeetingDateForm : ViewComponent
    {
        private readonly IDateRepository _dateRepository;

        public MeetingDateForm(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }

        public IViewComponentResult Invoke(int yearId)
        {
            var year = _dateRepository.GetYear(yearId);
            if (year == null)
            {
                return View("DateError");
            }
            ViewBag.YearId = yearId;
            ViewBag.ClientId = year.ClientId;
            if (year.MeetingDate is null)
            {
                return View("AddMeetingDate", new DateViewModel(DateHelper.GetToday()));
            }
            else
            {
                return View("ChangeMeetingDate", new DateViewModel((DateOnly)year.MeetingDate));
            }
        }
    }
}
