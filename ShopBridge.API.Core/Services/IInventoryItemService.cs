using ShopBridge.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Core.Services
{
    public interface IInventoryItemService
    {
        Task<IEnumerable<InventoryItem>> GetAll();
        Task<InventoryItem> Get(long id);
        Task<InventoryItem> Update(InventoryItem entity);
        Task<InventoryItem> Add(InventoryItem entity);
        Task<InventoryItem> Delete(long id);
    }
}
