using ShopBridge.API.Core.Models;
using ShopBridge.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.API.Data.Repositories
{
    public class InventoryRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
    {
        private InventoryContext context;
        public InventoryRepository(InventoryContext context)
          : base(context)
        {
            this.context = context;

        }
    }
}
