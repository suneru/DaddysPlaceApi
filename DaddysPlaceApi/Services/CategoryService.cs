using AutoMapper;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task<CategoryViewEntity> GetCategory(int id)
        {
            var item = await _categoryRepository.GetCategory(id);
            var responce = _mapper.Map<CategoryViewEntity>(item);
            return responce;
        }

        public async Task<IEnumerable<CategoryViewEntity>> GetCategories()
        {
            var item = await _categoryRepository.GetCategories();
            var responce = _mapper.Map<IEnumerable<CategoryViewEntity>>(item);
            return responce;
        }

        public async Task<int> CountOfCategories()
        {
            var item = await _categoryRepository.CountOfCategories();
            var responce = (item);
            return responce;
        }
    }
}
