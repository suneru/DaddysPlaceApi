namespace DaddysPlaceApi.ViewEntity
{
    public class OrderViewEntity
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public long? Discount { get; set; }
        public long Total { get; set; }
    }
}
