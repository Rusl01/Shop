﻿using Shop.Data.Models;

namespace Shop.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<car> Cars { get; }
        IEnumerable<car> GetFavCars { get; set; }
        car GetObjectCar(int carId);
    }
}
