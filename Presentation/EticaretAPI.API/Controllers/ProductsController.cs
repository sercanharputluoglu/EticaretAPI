using EticaretAPI.Application.Abstractions;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        /*private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();   
            return Ok(products);
        }*/

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            /*await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 130}
            });
            await _productWriteRepository.SaveAsync();
            */
            Product p = await _productReadRepository.GetByIdAsync("693b181a-5fa5-43f8-bb95-610d59d5d41a", false);
            p.Name = "mehmet";
            await _productWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool deleted = await _productWriteRepository.RemoveAsync(id);

            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
