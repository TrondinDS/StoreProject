using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.ModelDTO.Product
{
    /// <summary>
    /// Модель представления продукта DTO
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название продукта
        /// </summary>
        [Required(ErrorMessage = "Name является обязательным полем")]
        public string Name { get; set; }
        /// <summary>
        /// Цена продукта
        /// </summary>
        [Range(0, float.MaxValue, ErrorMessage = "Price должно быть положительным")]
        public float Price { get; set; }
        /// <summary>
        /// Идентификатор цены продукта
        /// </summary>
        [Required(ErrorMessage = "ProductTypeId является обязательным полем")]
        public int ProductTypeId { get; set; }
        /// <summary>
        /// Количество продукта доступное для заказа
        /// </summary>
        [Range(0, float.MaxValue, ErrorMessage = "Count должно быть положительным")]
        public int Count { get; set; }

    }
}
