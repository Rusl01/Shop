using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCatecoty;

        public CarsController(IAllCars allCars, ICarsCategory carsCatecoty)
        {
            _allCars = allCars;
            _carsCatecoty = carsCatecoty;
        }

        public ViewResult List()
        {
            CarsListViewModel obj = new CarsListViewModel();
            obj.AllCars = _allCars.Cars;
            obj.currCategory = "auto";
            ViewBag.Title = "Страница автомобилей";


             return View(obj);
        }

    }
}
