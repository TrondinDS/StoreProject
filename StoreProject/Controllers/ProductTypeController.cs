using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreProject.DB.DTO.ProductType;
using StoreProject.DB.Models;
using StoreProject.Services.Interfaces;

namespace StoreProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService productTypeService;
        private readonly IMapper mapper;

        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)
        {
            this.productTypeService = productTypeService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получение всех типов товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeDTO>>> GetAllProductTypes()
        {
            var productTypes = await productTypeService.GetAllAsync();
            var productTypeDtos = mapper.Map<IEnumerable<ProductTypeDTO>>(productTypes);
            return Ok(productTypeDtos);
        }

        // <summary>
        /// Получение типа товара по ID
        /// </summary>
        /// <param name="id">ID типа товара</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeDTO>> GetProductTypeById(int id)
        {
            var productType = await productTypeService.GetByIdAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            var productTypeDto = mapper.Map<ProductTypeDTO>(productType);
            return Ok(productTypeDto);
        }

        /// <summary>
        /// Создание нового типа товара
        /// </summary>
        /// <param name="productTypeDto">Данные нового типа товара</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateProductType(ProductTypeDTO productTypeDto)
        {
            var productType = mapper.Map<ProductType>(productTypeDto);
            await productTypeService.AddAsync(productType);
            return CreatedAtAction(nameof(GetProductTypeById), new { id = productType.Id }, productTypeDto);
        }

        /// <summary>
        /// Обновление типа товара
        /// </summary>
        /// <param name="id">ID типа товара</param>
        /// <param name="productTypeDto">Обновленные данные типа товара</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, ProductTypeDTO productTypeDto)
        {
            if (id != productTypeDto.Id)
            {
                return BadRequest();
            }

            var productType = mapper.Map<ProductType>(productTypeDto);
            await productTypeService.UpdateAsync(productType);
            return NoContent();
        }
        /// <summary>
        /// Удаление типа товара
        /// </summary>
        /// <param name="id">ID типа товара</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            await productTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}