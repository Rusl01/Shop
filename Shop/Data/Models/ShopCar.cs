using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
	public class ShopCar
	{
		private readonly AppDBContent appDBContent;
		public ShopCar(AppDBContent _appDBContent)
		{
			appDBContent = _appDBContent;
		}

		public string ShopCarId { get; set; }

		public List<ShopCarItem> ListShopItem { get; set; }

		public static ShopCar GetCar( IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDBContent>();
			string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCarId);

			return new ShopCar(context) { ShopCarId = shopCarId };	
		}

		public void AddToCar(car car)
		{
			appDBContent.ShopCarItem.Add(new ShopCarItem
			{
				ShopCarId = ShopCarId,
				Car = car,
				Price = car.Price
			});
			appDBContent.SaveChanges();
		}

		public List<ShopCarItem> GetShopItems()
		{
			return appDBContent.ShopCarItem.Where(c => c.ShopCarId== ShopCarId).Include(s => s.Car).ToList();
		}
	}
}
