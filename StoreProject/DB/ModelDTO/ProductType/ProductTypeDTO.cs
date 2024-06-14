using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.DTO.ProductType
{
    /// <summary>
    /// Модель представления типа продукта DTO
    /// </summary>
    public class ProductTypeDTO
    {
        /// <summary>
        /// Идентификатор типа продукта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя типа продукта
        /// </summary>
        [Required(ErrorMessage = "Название типа продукта обязательно.")]
        [StringLength(100, ErrorMessage = "Название типа продукта не должно превышать 100 символов.")]
        public string Name { get; set; }
    }
}
