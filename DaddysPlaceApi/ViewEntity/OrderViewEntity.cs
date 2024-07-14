namespace DaddysPlaceApi.ViewEntity
{
    public class OrderViewEntity
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
        public float Total { get; set; }
    }
}
