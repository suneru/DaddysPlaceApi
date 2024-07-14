using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            this._itemRepository = itemRepository;
            this._mapper = mapper;
        }

        public async Task<ItemViewEntity> CreateItem(ItemViewEntity itemViewEntity)
        {
            var entity = _mapper.Map<ItemEntity>(itemViewEntity);
            var createItem = await _itemRepository.CreateItem(entity);
            var responce = _mapper.Map<ItemViewEntity>(createItem);
            return responce;
        }

        public async Task DeleteItem(int id)
        {
            await _itemRepository.DeleteItem(id);
        }

        public async Task<ItemViewEntity> GetItem(int id)
        {
            var item = await _itemRepository.GetItem(id);
            var responce = _mapper.Map<ItemViewEntity>(item);
            return responce;
        }

        public async Task<IEnumerable<ItemViewEntity>> GetItems()
        {
            var item = await _itemRepository.GetItems();
            var responce = _mapper.Map<IEnumerable<ItemViewEntity>>(item);
            return responce;
        }

        public async Task UpdateItem(int id, ItemViewEntity itemViewEntity)
        {
            var entity = _mapper.Map<ItemEntity>(itemViewEntity);
            await _itemRepository.UpdateItem(id, entity);
        }
    }
}
