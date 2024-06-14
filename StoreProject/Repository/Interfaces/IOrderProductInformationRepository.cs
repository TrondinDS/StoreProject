using StoreProject.DB.Models;
using StoreProject.Repository.Generic;

namespace StoreProject.Repository.Interfaces
{
    public interface IOrderProductInformationRepository : IGenericRepository<OrderInformation, int>
    {
    }
}
