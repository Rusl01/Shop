using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly MockCategory _categotyCar = new MockCategory();
        public IEnumerable<car> Cars
        {
            get
            {
                return new List<car>
                {
                    new car
                    {
                        Name="Tesla Plaid", 
                        ShortDesc="Не машина,а игрушка", 
                        LongDesc="", 
                        Img="", 
                        Price=4500, 
                        IsFavourite=true, 
                        Available=true, 
                        Category = _categotyCar.AllCategory.First() 
                    },
                    new car
                    {
                        Name="BMW m5",
                        ShortDesc="Бешеная табуретка",
                        LongDesc="",
                        Img="",
                        Price=5300,
                        IsFavourite=true,
                        Available=true,
                        Category = _categotyCar.AllCategory.Last()
                    },
                    new car
                    {
                        Name="Ford Focus",
                        ShortDesc="для семьи и для себя",
                        LongDesc="",
                        Img="",
                        Price=3000,
                        IsFavourite=true,
                        Available=true,
                        Category = _categotyCar.AllCategory.Last()
                    },
                    new car
                    {
                        Name="BMW i3",
                        ShortDesc="Что-то из будущего",
                        LongDesc="",
                        Img="",
                        Price=4500,
                        IsFavourite=true,
                        Available=true,
                        Category = _categotyCar.AllCategory.First()
                    }
                };
            }
        }
        public IEnumerable<car> GetFavCars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
