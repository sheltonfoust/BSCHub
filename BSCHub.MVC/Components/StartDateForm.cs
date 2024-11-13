using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Clients;
using BSCHub.MVC.ViewModels;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;

namespace BSCHub.MVC.Components
{
    public class StartDateForm : ViewComponent
    {
        private readonly IDateRepository _dateRepository;

        public StartDateForm(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }
        public IViewComponentResult Invoke(int yearId)
        {            
            ViewBag.YearId = yearId;
            var startDate = _dateRepository.GetYear(yearId)?.StartDate;
            if (startDate == null)
            {
                return View("DateError");
            }
            var view = View(new DateViewModel((DateOnly)startDate));
            return view;
        }
    }
}
