using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<car> AllCars { get; set; }
        public string currCategory { get; set; }

    }
}
