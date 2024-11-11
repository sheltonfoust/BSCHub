using BSCHub.Application;
using BSCHub.Domain.Clients;
using System.ComponentModel.DataAnnotations;

namespace BSCHub.MVC.ViewModels
{
    public class DatesListViewModel
    {
        public List<ISP_Year> ISP_Years { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.Date)]
        public DateOnly NewYearStart { get; set; } = DateHelper.GetToday();
        [DataType(DataType.Date)]
        public DateOnly NewEditMeetingDate { get; set; } = DateHelper.GetToday();
        [DataType(DataType.Date)]
        public DateOnly NewSetMeetingDate { get; set; } = DateHelper.GetToday();
        public DatesListViewModel(Client client, List<ISP_Year> ISP_Years)
        {
            Client = client;
            this.ISP_Years = ISP_Years;
        }
    }
}
