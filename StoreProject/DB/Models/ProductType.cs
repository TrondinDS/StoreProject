using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class ProductType : IsDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
