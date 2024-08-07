namespace DaddysPlaceApi.ViewEntity.AllViewEntity
{
    public class AllBillViewEntity
    {
        public int Id { get; set; }
        public string CreateOn { get; set; }
        public int Frn_UserId { get; set; }
        public string BillTotal { get; set; }
        public string Email { get; set; }
        public string PaymentType { get; set; }
        public double TotalAmount { get; set; }
    }
}
