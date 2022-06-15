namespace Shop.Data.Models
{
    public class ShopCarItem
    {
        public int Id { get; set; }
        public car Car { get; set; }
        public int Price { get; set; }
        public string ShopCarId { get; set; }
    }
}
