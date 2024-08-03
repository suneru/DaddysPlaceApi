using DaddysPlaceApi.ViewEntity;
using DaddysPlaceApi.ViewEntity.AllViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewEntity>> GetProducts();
        public Task<IEnumerable<AllProductViewEntity>> GetProductsJoin();
        public Task<ProductViewEntity> GetProduct(int id);
        public Task<ProductViewEntity> FetchbyProductName(string name);
        public Task<IEnumerable<ProductViewEntity>> GetCategoryWiseProductItem(int Category);
        public Task<ProductViewEntity> CreateProduct(ProductViewEntity productViewEntity);
        public Task UpdateProduct(int id, ProductViewEntity productViewEntity);
        public Task DeleteProduct(int id);
    }
}
