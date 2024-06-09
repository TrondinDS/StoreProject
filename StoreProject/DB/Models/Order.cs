using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class Order : IsDelete
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}