using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class User : IsDelete
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NumberPhone { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
