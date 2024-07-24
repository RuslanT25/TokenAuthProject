using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AuthServer.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBaseService<Product, ProductDTO> _productService;

        public ProductController(IBaseService<Product, ProductDTO> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetAllAsync();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDTO productDto)
        {
            var result = await _productService.AddAsync(productDto);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDto)
        {
            var result = await _productService.Update(productDto, productDto.Id);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.Remove(id);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
