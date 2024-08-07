using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IBillRepositor
    {
        public Task<IEnumerable<BillEntity>> GetBills();
        public Task<BillEntity> GetBill(int id);
        public Task<BillEntity> CreateBill(BillEntity billEntity);
        public Task UpdateBill(int id, BillEntity billEntity);
        public Task DeleteBill(int id);
        public Task<BillOrdernoEntity> GetBillOrderNo();
    }
}
