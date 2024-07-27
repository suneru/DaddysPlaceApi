using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<PaymentViewEntity>> GetPayments();
        public Task<PaymentViewEntity> GetPayment(int id);
        public Task<PaymentViewEntity> CreatePayment(PaymentViewEntity paymentViewEntity);
        public Task UpdatePayment(int id, PaymentViewEntity paymentViewEntity);
        public Task DeletePayment (int id);
    }
}
