namespace DaddysPlaceApi.Entity
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public double Discount { get; set; }
        public double Quanlity { get; set; }
        public double Price { get; set; }
        public int Frn_ProductId { get; set; }
        public int Frn_OrderId { get; set; }
    }
}

