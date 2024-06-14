namespace StoreProject.DB.ModelDTO.Product
{
    /// <summary>
    /// Представление продукта для фильтрации
    /// </summary>
    public class ProductFilterDTO
    {
        /// <summary>
        /// Флаг идентификатор типа продукта для фильтрации (если флаг == null все товары)
        /// </summary>
        public int ProductTypeId { get; set; }
        /// <summary>
        /// Флаг фильтрации для доступных | недоступных товаров (если флаг == null все товары)
        /// </summary>
        public bool? isAvailable { get; set; }
        /// <summary>
        /// Флаг сортировки товаров по возрастанию | убыванию
        /// </summary>
        public bool? isAscending { get; set; } = true;
    }
}
