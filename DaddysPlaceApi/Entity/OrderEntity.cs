namespace DaddysPlaceApi.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public double Total { get; set; }
    }
}
