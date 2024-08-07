using AutoMapper;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _PaymentTypeRepository;
        private readonly IMapper _mapper;

        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            this._PaymentTypeRepository = paymentTypeRepository;
            this._mapper = mapper;
        }

        public async Task<PaymentTypeViewEntity> GetPaymentType(int id)
        {
            var item = await _PaymentTypeRepository.GetPaymentType(id);
            var responce = _mapper.Map<PaymentTypeViewEntity>(item);
            return responce;
        }

        public async Task<IEnumerable<PaymentTypeViewEntity>> GetPaymentTypes()
        {
            var item = await _PaymentTypeRepository.GetPaymentTypes();
            var responce = _mapper.Map<IEnumerable<PaymentTypeViewEntity>>(item);
            return responce;
        }
    }
}
