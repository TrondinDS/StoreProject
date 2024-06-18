using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class OrderItem : IsDelete
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderInformationId { get; set; }
        public virtual OrderInformation OrderInformation { get; set; }
    }
}