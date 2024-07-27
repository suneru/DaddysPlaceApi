using DaddysPlaceApi.Entity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public ItemRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<ItemEntity> CreateItem(ItemEntity itemEntity)
        {
            string sqlString = "INSERT INTO Item (Discount,Quanlity,Price,Frn_ProductId,Frn_OrderId) " +
                               " VALUES (@Discount,@Quanlity,@Price,@Frn_ProductId,@Frn_OrderId)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int itemId = await con.ExecuteScalarAsync<int>(sqlString, itemEntity);
            itemEntity.Id = itemId;
            return itemEntity;
        }
        public async Task DeleteItem(int id)
        {
            string sqlString = "DELETE * FROM Item WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<ItemEntity> GetItem(int id)
        {
            string sqlString = "SELECT * FROM Item WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var itemId = await con.QuerySingleOrDefaultAsync<ItemEntity>(sqlString, new { id });
            return itemId;
        }

        public async Task<IEnumerable<ItemEntity>> GetItems()
        {
            string sqlString = "SELECT * FROM Item";
            var con = _dbConnectors.CreateConnection();
            var item = await con.QueryAsync<ItemEntity>(sqlString);
            return item.ToList();
        }

        public async Task UpdateItem(int id, ItemEntity itemEntity)
        {
            string sqlString = "UPDATE [Item] SET Discount=@Discount,Quanlity=@Quanlity,Price=@Price,Frn_ProductId=@Frn_ProductId,Frn_OrderId=@Frn_OrderId " +
                               "WHERE Id=@Id";
            itemEntity.Id=id;
            var con = _dbConnectors.CreateConnection();
            await con.ExecuteAsync(sqlString, itemEntity);

        }
    }
}
