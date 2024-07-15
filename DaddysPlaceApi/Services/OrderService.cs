using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task<OrderViewEntity> CreateOrder(OrderViewEntity orderViewEntity)
        {
            var entity = _mapper.Map<OrderEntity>(orderViewEntity);
            var createOrder = await _orderRepository.CreateOrder(entity);
            var responce = _mapper.Map<OrderViewEntity>(createOrder);
            return responce;
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        public async Task<OrderViewEntity> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            var responce = _mapper.Map<OrderViewEntity>(order);
            return responce;
        }

        public async Task<IEnumerable<OrderViewEntity>> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            var responce = _mapper.Map<IEnumerable<OrderViewEntity>>(orders);
            return responce;
        }

        public async Task UpdateOrder(int id, OrderViewEntity orderViewEntity)
        {
            var entity = _mapper.Map<OrderEntity>(orderViewEntity);
            await _orderRepository.UpdateOrder(id, entity);
        }
    }
}
