namespace DaddysPlaceApi.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public float Receive { get; set; }
        public float Refund { get; set; }
        public int Type { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
