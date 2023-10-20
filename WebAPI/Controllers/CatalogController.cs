using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> logger;
        private readonly IServiceManager _serviceManager;

        public CatalogController(IServiceManager serviceManager, ILogger<CatalogController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Category/GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var result = await _serviceManager.CategoryService.GetCategory(categoryId);
            return Ok(result);
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Category/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _serviceManager.CategoryService.GetAllCategories();
            return Ok(result);
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Category/AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category entity)
        {
            var result = await _serviceManager.CategoryService.AddCategory(entity);
            return Ok(result);
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Category/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category entity)
        {
            var result = await _serviceManager.CategoryService.UpdateCategory(entity);
            return Ok(result);
        }

        // DELETE api/<CatalogController>/delete/5
        [HttpDelete("Category/DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int? categoryId)
        {
            var result = await _serviceManager.CategoryService.RemoveCategory(categoryId);
            return Ok(result);
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Item/GetItem/{itemId}")]
        public async Task<IActionResult> GetItem(int itemId)
        {
            var result = await _serviceManager.ItemService.GetItem(itemId);
            return Ok(result);
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Item/GetItem/{categoryId}")]
        public async Task<IActionResult> GetItems(int categoryId)
        {
            var result = await _serviceManager.ItemService.GetItems(categoryId);
            return Ok(result);
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Item/AddItem")]
        public async Task<IActionResult> AddItem([FromBody] Item entity)
        {
            var result = await _serviceManager.ItemService.AddItem(entity);
            return Ok(result);
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Item/UpdateItem")]
        public async Task<IActionResult> UpdateItem([FromBody] Item entity)
        {
            var result = await _serviceManager.ItemService.UpdateItem(entity);
            return Ok(result);
        }

        // DELETE api/<CatalogController>/delete/5
        [HttpDelete("Item/DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(int? itemId)
        {
            var result = await _serviceManager.ItemService.RemoveItem(itemId);
            return Ok(result);
        }
    }
}
