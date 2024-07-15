namespace DaddysPlaceApi.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public double Receive { get; set; }
        public double Refund { get; set; }
        public int Type { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
