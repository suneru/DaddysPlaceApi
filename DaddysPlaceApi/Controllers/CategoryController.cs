using DaddysPlaceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public ILogger<CategoryController> _Logger { get; }

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this._categoryService = categoryService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var items = await _categoryService.GetCategories();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _categoryService.GetCategory(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
