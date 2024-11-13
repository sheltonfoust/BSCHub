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
            
            var year = _dateRepository.GetYear(yearId);
            if (year == null)
            {
                return View("DateError");
            }
            ViewBag.YearId = yearId;
            ViewBag.ClientId = year.ClientId;
            var view = View(new DateViewModel(year.StartDate));
            return view;
        }
    }
}
