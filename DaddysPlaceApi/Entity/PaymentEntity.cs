namespace DaddysPlaceApi.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public long Receive { get; set; }
        public long Refund { get; set; }
        public int Type { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
