using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class ProductInformation : IsDelete
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CountProduct { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}