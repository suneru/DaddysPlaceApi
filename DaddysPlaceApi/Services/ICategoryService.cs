using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryViewEntity>> GetCategories();
        public Task<CategoryViewEntity> GetCategory(int id);
        public Task<int> CountOfCategories();
    }
}
