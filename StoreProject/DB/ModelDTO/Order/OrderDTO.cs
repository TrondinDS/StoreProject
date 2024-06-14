using StoreProject.DB.ModelDTO.OrderItem;
using StoreProject.DB.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.ModelDTO.Order
{
    public class OrderDTO
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор клиента, к которому привязан заказ
        /// </summary>
        [Required(ErrorMessage = "UserId обязательное поле")]
        public int UserId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        [Required(ErrorMessage = "DateCreate обязательное поле")]
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Список элементов заказа
        /// </summary>
        [Required(ErrorMessage = "OrderItems обязательное поле")]
        [MinLength(1, ErrorMessage = "Заказ должен содержать минимум 1 элемент")]
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
