using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class OrderItem : IsDelete
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<OrderProductInformation> OrderProductInformation { get; set; }
    }
}