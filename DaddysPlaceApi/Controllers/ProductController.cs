﻿using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ILogger<ProductController> _Logger { get; }

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this._productService = productService;
            _Logger = logger;
        }

        [HttpGet("ListAdvance")]
        public async Task<IActionResult> ListAdvance()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("ListAdvanceALL")]
        public async Task<IActionResult> ListAdvanceALL()
        {
            var products = await _productService.GetProductsJoin();
            return Ok(products);
        }

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("FetchbyId/{name}")]
        public async Task<IActionResult> FetchbyProductName(string name)
        {
            var product = await _productService.FetchbyProductName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("GetCategoryWiseProductItem/{categoryId}")]
        public async Task<IActionResult> GetCategoryWiseProductItem(int categoryId)
        {
            var product = await _productService.GetCategoryWiseProductItem(categoryId);
            
            return Ok(product);
        }



        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProductViewEntity productViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            ProductViewEntity productExist = new ProductViewEntity();
            productExist = await _productService.FetchbyProductName(productViewEntity.Name);
            if (productExist == null)
            {
                var createResponce = await _productService.CreateProduct(productViewEntity);
                return Ok(createResponce);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Found);
            }

        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductViewEntity productViewEntity)
        {
            var productExist = await _productService.GetProduct(id);
            if (productExist == null)
                return NotFound();
            await _productService.UpdateProduct(id, productViewEntity);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productExist = await _productService.GetProduct(id);
            if (productExist == null)
                return NotFound();
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
