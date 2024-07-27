using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IPaymentRepository
    {
        public Task<IEnumerable<PaymentEntity>> GetPayments();
        public Task<PaymentEntity> GetPayment(int id);
        public Task<PaymentEntity> CreatePayment(PaymentEntity paymentEntity);
        public Task UpdatePayment(int id, PaymentEntity paymentEntity);
        public Task DeletePayment(int id);


    }
}
