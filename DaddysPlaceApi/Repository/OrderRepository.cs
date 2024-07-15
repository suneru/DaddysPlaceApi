using DaddysPlaceApi.Entity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public OrderRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity orderEntity)
        {
            string sqlString = "INSERT INTO [Order] (Price,Discount,Total) " +
                               " VALUES (@Price,@Discount,@Total)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int orderid = await con.ExecuteScalarAsync<int>(sqlString, orderEntity);
            orderEntity.Id = orderid;
            return orderEntity;
        }
        public async Task DeleteOrder(int id)
        {
            string sqlString = "DELETE * FROM [Order] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<OrderEntity> GetOrder(int id)
        {
            string sqlString = "SELECT * FROM [Order] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var order = await con.QuerySingleOrDefaultAsync(sqlString, new { id });
            return order;
        }

        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            string sqlString = "SELECT * FROM [Order]";
            var con = _dbConnectors.CreateConnection();
            var order = await con.QueryAsync<OrderEntity>(sqlString);
            return order.ToList();
        }

        public async Task UpdateOrder(int id, OrderEntity orderEntity)
        {
            string sqlString = "UPDATE [Order] SET Price=@Price,Discount=@Discount,Total=@Total " +
                               "WHERE Id=@Id";

            var con = _dbConnectors.CreateConnection();
            await con.ExecuteAsync(sqlString);

        }

    }
}
