using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.ModelDTO.Order
{
    /// <summary>
    /// DTO для создания заказа
    /// </summary>
    public class OrderCreateDTO
    {
        /// <summary>
        /// Идентификатор клиента, для которого создается заказ
        /// </summary>
        [Required(ErrorMessage = "UserId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than zero")]
        public int UserId { get; set; }
        /// <summary>
        /// Словарь, содержащий идентификаторы товаров и их количество в заказе
        /// </summary
        [Required(ErrorMessage = "OrderItems are required")]
        [MinLength(1, ErrorMessage = "OrderItems must contain at least one item")]
        public Dictionary<int, int> OrderItems { get; set; }
    }
}
