namespace DaddysPlaceApi.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
        public float Total { get; set; }
    }
}
