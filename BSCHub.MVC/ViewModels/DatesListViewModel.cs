using BSCHub.Application;
using BSCHub.Domain.Clients;
using BSCHub.Domain.Dates;
using System.ComponentModel.DataAnnotations;

namespace BSCHub.MVC.ViewModels
{
    public class DatesListViewModel
    {
        public List<YearWithReports> ISP_Years { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.Date)]
        public DateOnly NewYearStart { get; set; } = DateHelper.GetToday();
        public DatesListViewModel(Client client, List<YearWithReports> ISP_Years)
        {
            Client = client;
            this.ISP_Years = ISP_Years;
        }
    }
}
