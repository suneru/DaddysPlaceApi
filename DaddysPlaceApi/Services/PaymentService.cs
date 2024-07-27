using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            this._paymentRepository = paymentRepository;
            this._mapper = mapper;
        }

        public async Task<PaymentViewEntity> CreatePayment(PaymentViewEntity paymentViewEntity)
        {
            var entity = _mapper.Map<PaymentEntity>(paymentViewEntity);
            var createPayment = await _paymentRepository.CreatePayment(entity);
            var responce = _mapper.Map<PaymentViewEntity>(createPayment);
            return responce;
        }

        public async Task DeletePayment(int id)
        {
            await _paymentRepository.DeletePayment(id);
        }

        public async Task<PaymentViewEntity> GetPayment(int id)
        {
            var payments = await _paymentRepository.GetPayment(id);
            var responce = _mapper.Map<PaymentViewEntity>(payments);
            return responce;
        }

        public async Task<IEnumerable<PaymentViewEntity>> GetPayments()
        {
            var payments = await _paymentRepository.GetPayments();
            var responce = _mapper.Map<IEnumerable<PaymentViewEntity>>(payments);
            return responce;
        }

        public async Task UpdatePayment(int id, PaymentViewEntity paymentViewEntity)
        {
            var entity = _mapper.Map<PaymentEntity>(paymentViewEntity);
            await _paymentRepository.UpdatePayment(id, entity);
        }
    }
}
