using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;

using Shop.ViewModels;

namespace Shop.Controllers
{
	public class ShopCarController:Controller
	{
		private readonly IAllCars _carRep;
		private readonly ShopCar _ShopCar;

		public ShopCarController(IAllCars carRep, ShopCar shopCar)
		{
			_carRep = carRep;
			_ShopCar = shopCar;
		}

		public ViewResult Index()
		{
			var items = _ShopCar.GetShopItems();
			_ShopCar.ListShopItem = items;

			var obj = new ShopCarViewModel
			{
				shopCar = _ShopCar
			};
			return View(obj);
		}

		public RedirectToActionResult addToCar(int id)
		{
			var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
			if(item != null)
			{
				_ShopCar.AddToCar(item);
			}
			return RedirectToAction("index");
		}
	}
}
