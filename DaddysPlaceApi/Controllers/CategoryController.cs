using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var categores = await _categoryService.GetCategory(id);
            if (categores == null)
            {
                return NotFound();
            }
            return Ok(categores);
        }



        [HttpGet("GetCoutOfCategories")]
        public async Task<IActionResult> CountOfCategories()
        {
            var items = await _categoryService.GetCategories();
            var catgories = await _categoryService.CountOfCategories();
            AllCategoriesEntity allCategoriesEntity = new AllCategoriesEntity();
            allCategoriesEntity.CountofCategories= catgories;
            allCategoriesEntity.AllCategories = items;
            return Ok(allCategoriesEntity);
        }
    }
}
