namespace DaddysPlaceApi.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public double Receive_Amount { get; set; }
        public double Balance_Amount { get; set; }
        public int Payment_Type { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
