namespace DaddysPlaceApi.ViewEntity
{
    public class OrderViewEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
    }
}
