﻿namespace DaddysPlaceApi.ViewEntity
{
    public class BillViewEntity
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public int Frn_UserId { get; set; }
        public int Frn_PaymentId { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
