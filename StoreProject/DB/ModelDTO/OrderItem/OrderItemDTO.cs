using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.ModelDTO.OrderItem
{
    /// <summary>
    /// DTO для представления элемента заказа
    /// </summary>
    public class OrderItemDTO
    {
        /// <summary>
        /// Идентификатор элемента заказа
        /// </summary>
        public int Id { get; set; }

        // <summary>
        /// Идентификатор заказа, к которому привязан элемент заказа
        /// </summary>
        [Required(ErrorMessage = "OrderId is required")]
        public int OrderId { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public float Price { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        [Required(ErrorMessage = "Count is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Count must be at least one")]
        public int Count { get; set; }
    }
}
