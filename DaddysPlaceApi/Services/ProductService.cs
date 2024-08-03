using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;
using DaddysPlaceApi.ViewEntity.AllViewEntity;

namespace DaddysPlaceApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<ProductViewEntity> CreateProduct(ProductViewEntity productViewEntity)
        {
            var entity = _mapper.Map<ProductEntity>(productViewEntity);
            var createProduct = await _productRepository.CreateProduct(entity);
            var responce = _mapper.Map<ProductViewEntity>(createProduct);
            return responce;
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<ProductViewEntity> FetchbyProductName(string name)
        {
            var products = await _productRepository.FetchbyProductName(name);
            var responce = _mapper.Map<ProductViewEntity>(products);
            return responce;
        }
        public async Task<ProductViewEntity> GetProduct(int id)
        {
            var products = await _productRepository.GetProduct(id);
            var responce = _mapper.Map<ProductViewEntity>(products);
            return responce;
        }

        public async Task<IEnumerable<ProductViewEntity>> GetCategoryWiseProductItem(int Category)
        {
            var products = await _productRepository.GetCategoryWiseProductItem(Category);
            var responce = _mapper.Map<IEnumerable<ProductViewEntity>>(products);
            return responce;
        }

        public async Task<IEnumerable<ProductViewEntity>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var responce = _mapper.Map<IEnumerable<ProductViewEntity>>(products);
            return responce;
        }

        public async Task<IEnumerable<AllProductViewEntity>> GetProductsJoin()
        {
            var products = await _productRepository.GetProductsJoin();
            var responce = _mapper.Map<IEnumerable<AllProductViewEntity>>(products);
            return responce;
        }

        public async Task UpdateProduct(int id, ProductViewEntity productViewEntity)
        {
            var entity = _mapper.Map<ProductEntity>(productViewEntity);
            await _productRepository.UpdateProduct(id, entity);
        }
    }
}
