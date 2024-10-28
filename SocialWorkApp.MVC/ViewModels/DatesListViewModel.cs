using SocialWorkApp.Domain.Clients;
using System.ComponentModel.DataAnnotations;

namespace SocialWorkApp.MVC.ViewModels
{
    public class DatesListViewModel
    {
        public List<ISP_Year> ISP_Years { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.Date)]
        public DateOnly NewYearStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [DataType(DataType.Date)]
        public DateOnly NewEditMeetingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [DataType(DataType.Date)]
        public DateOnly NewSetMeetingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DatesListViewModel(Client client, List<ISP_Year> ISP_Years)
        {
            Client = client;
            this.ISP_Years = ISP_Years;
        }
    }
}
