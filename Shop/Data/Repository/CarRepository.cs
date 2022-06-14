using Microsoft.EntityFrameworkCore;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }

        public IEnumerable<car> Cars => appDBContent.Car.Include(c=> c.Category);

        public IEnumerable<car> GetFavCars => appDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public car GetObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.Id == carId);
    }
}
