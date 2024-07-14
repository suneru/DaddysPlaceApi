namespace DaddysPlaceApi.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public long? Discount { get; set; }
        public long Total { get; set; }
    }
}
