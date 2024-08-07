using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IBillService
    {
        public Task<IEnumerable<BillViewEntity>> GetBills();
        public Task<BillViewEntity> GetBill(int id);
        public Task<BillViewEntity> CreateBill(BillViewEntity billViewEntity);
        public Task UpdateBill(int id, BillViewEntity billViewEntity);
        public Task DeleteBill(int id);
        public Task<BillViewOrdernoEntity> GetBillOrderNo();
    }
}
