using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductEntity>> GetProducts();
        public Task<ProductEntity> GetProduct(int id);
        public Task<IEnumerable<ProductEntity>> GetCategoryWiseProductItem(int Category);
        public Task<ProductEntity> CreateProduct(ProductEntity productEntity);
        public Task UpdateProduct(int id, ProductEntity productEntity);
        public Task DeleteProduct(int id);
    }
}
