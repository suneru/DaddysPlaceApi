using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemViewEntity>> GetItems();
        public Task<ItemViewEntity> GetItem(int id);
        public Task<ItemViewEntity> CreateItem(ItemViewEntity itemViewEntity);
        public Task UpdateItem(int id, ItemViewEntity itemViewEntity);
        public Task DeleteItem(int id);
    }
}
