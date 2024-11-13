
using System.ComponentModel.DataAnnotations;

namespace BSCHub.MVC.ViewModels
{
    public class DateViewModel
    {
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        public DateViewModel()
        {
            
        }
        public DateViewModel(DateOnly date)
        {
            Date = date;
        }
    }
}
