using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IPaymentTypeService
    {
        public Task<IEnumerable<PaymentTypeViewEntity>> GetPaymentTypes();
        public Task<PaymentTypeViewEntity> GetPaymentType(int id);
    }
}
