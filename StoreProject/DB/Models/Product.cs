using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Models
{
    public class Product : IsDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ICollection<OrderProductInformation> ProductInformations { get; set; }
    }
}