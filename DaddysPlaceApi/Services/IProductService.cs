using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewEntity>> GetProducts();
        public Task<ProductViewEntity> GetProduct(int id);
        public Task<IEnumerable<ProductViewEntity>> GetCategoryWiseProductItem(int Category);
        public Task<ProductViewEntity> CreateProduct(ProductViewEntity productViewEntity);
        public Task UpdateProduct(int id, ProductViewEntity productViewEntity);
        public Task DeleteProduct(int id);
    }
}
