using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<OrderEntity>> GetOrders();
        public Task<OrderEntity> GetOrder(int id);
        public Task<OrderEntity> CreateOrder(OrderEntity orderEntity);
        public Task UpdateOrder(int id, OrderEntity orderEntity);
        public Task DeleteOrder(int id);
    }
}
