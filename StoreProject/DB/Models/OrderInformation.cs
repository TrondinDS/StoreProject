using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class OrderInformation : IsDelete
    {
        public int OrderInformationId { get; set; }
        public bool IsDeleted { get; set; }
        public int CountProduct { get; set; }
        public float Price { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}