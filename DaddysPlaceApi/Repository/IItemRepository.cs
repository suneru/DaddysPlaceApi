using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IItemRepository
    {
        public Task<IEnumerable<ItemEntity>> GetItems();
        public Task<ItemEntity> GetItem(int id);
        public Task<ItemEntity[]> CreateItem(ItemEntity[] itemEntity);
        public Task UpdateItem(int id, ItemEntity itemEntity);
        public Task DeleteItem(int id);
    }
}
