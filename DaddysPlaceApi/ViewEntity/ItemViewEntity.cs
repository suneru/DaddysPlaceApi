namespace DaddysPlaceApi.ViewEntity
{
    public class ItemViewEntity
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public decimal Quanlity { get; set; }
        public decimal? Price { get; set; }
        public int Frn_ProductId { get; set; }
        public int Frn_OrderId { get; set; }
    }
}
