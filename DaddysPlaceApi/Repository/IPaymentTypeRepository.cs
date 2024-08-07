using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IPaymentTypeRepository
    {
        public Task<IEnumerable<PaymentTypeEntity>> GetPaymentTypes();
        public Task<PaymentTypeEntity> GetPaymentType(int id);
        
    }
}
