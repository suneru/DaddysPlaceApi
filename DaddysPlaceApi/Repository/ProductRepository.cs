using DaddysPlaceApi.Entity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public ProductRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<ProductEntity> CreateProduct(ProductEntity productEntity)
        {
            string sqlString = "INSERT INTO [Product] (Name,Price,Image,Category) " +
                               " VALUES (@Name,@Price,@Image,@Category)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int productid = await con.ExecuteScalarAsync<int>(sqlString, productEntity);
            productEntity.Id = productid;
            return productEntity;
        }
        public async Task DeleteProduct(int id)
        {
            string sqlString = "DELETE FROM [Product] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<ProductEntity> GetProduct(int id)
        {
            string sqlString = "SELECT * FROM [Product] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var product = await con.QuerySingleOrDefaultAsync<ProductEntity>(sqlString, new { id });
            return product;
        }

        public async Task<IEnumerable<ProductEntity>> GetCategoryWiseProductItem(int Category)
        {
            string sqlString = "SELECT * FROM [Product] WHERE Category=@Category";
            var con = _dbConnectors.CreateConnection();
            var product = await con.QueryAsync<ProductEntity>(sqlString, new { Category });
            return product;
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            string sqlString = "SELECT * FROM [Product]";
            var con = _dbConnectors.CreateConnection();
            var product = await con.QueryAsync<ProductEntity>(sqlString);
            return product.ToList();
        }

        public async Task UpdateProduct(int id, ProductEntity productEntity)
        {
            string sqlString = "UPDATE [Product] SET Name=@Name,Price=@Price,Image=@Image,Category=@Category " +
                               "WHERE Id=@Id";
            productEntity.Id=id;
            var con = _dbConnectors.CreateConnection();
            await con.ExecuteAsync(sqlString, productEntity);

        }
    }
}
