﻿using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;

namespace StoreProject.Repository
{
    public class OrderProductInformationRepository : GenericRepository<OrderProductInformation, int>, IOrderProductInformationRepository
    {
        public OrderProductInformationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
