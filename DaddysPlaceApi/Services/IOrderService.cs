using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderViewEntity>> GetOrders();
        public Task<OrderViewEntity> GetOrder(int id);
        public Task<OrderViewEntity> CreateOrder(OrderViewEntity orderViewEntity);
        public Task UpdateOrder(int id, OrderViewEntity orderViewEntity);
        public Task DeleteOrder(int id);
    }
}
