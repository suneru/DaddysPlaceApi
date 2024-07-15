﻿using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ILogger<ProductController> _Logger { get; }

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this._productService = productService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewEntity productViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce = await _productService.CreateProduct(productViewEntity);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductViewEntity productViewEntity)
        {
            var productExist = await _productService.GetProduct(id);
            if (productExist == null)
                return NotFound();
            await _productService.UpdateProduct(id, productViewEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
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