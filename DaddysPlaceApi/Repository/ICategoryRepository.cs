using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryEntity>> GetCategories();
        public Task<CategoryEntity> GetCategory(int id);
        public Task<int> CountOfCategories();
    }
}
