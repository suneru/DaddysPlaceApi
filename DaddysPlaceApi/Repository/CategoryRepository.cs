using DaddysPlaceApi.Entity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public CategoryRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<CategoryEntity> GetCategory(int id)
        {
            string sqlString = "SELECT * FROM Category WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var billId = await con.QuerySingleOrDefaultAsync<CategoryEntity>(sqlString, new { id });
            return billId;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            string sqlString = "SELECT * FROM Category";
            var con = _dbConnectors.CreateConnection();
            var categories = await con.QueryAsync<CategoryEntity>(sqlString);
            return categories.ToList();
        }

        public async Task<int> CountOfCategories()
        {
            string sqlString = "SELECT count(*) As CountCtegories FROM Category";
            var con = _dbConnectors.CreateConnection();
            var categoriesCount = await con.ExecuteScalarAsync<int>(sqlString);
            return categoriesCount;
        }
    }
}
