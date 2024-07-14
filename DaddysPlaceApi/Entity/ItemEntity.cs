namespace DaddysPlaceApi.Entity
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public float Discount { get; set; }
        public int Quanlity { get; set; }
        public float? Price { get; set; }
        public int Frn_ProductId { get; set; }
        public int Frn_OrderId { get; set; }
    }
}

