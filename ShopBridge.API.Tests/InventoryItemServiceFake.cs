using ShopBridge.API.Core.Models;
using ShopBridge.API.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Tests
{
    public class InventoryItemServiceFake : IInventoryItemService
    {

        private readonly List<InventoryItem> _inventoryItems;

        public InventoryItemServiceFake()
        {
            _inventoryItems = new List<InventoryItem>()
            {
                new InventoryItem() { Id = 1, Name = "Item 1", Manufacturer="Manufacturer 1", Price = 5.00M },
                new InventoryItem() { Id = 2, Name = "Item 2", Manufacturer="Manufacturer 1", Price = 5.00M },
                new InventoryItem() { Id = 3, Name = "Item 3", Manufacturer="Manufacturer 1", Price = 5.00M }

            };
        }
        public async Task<InventoryItem> Add(InventoryItem entity)
        {
            entity.Id = _inventoryItems.Count+1;
            _inventoryItems.Add(entity);
            return entity;
        }

        public async Task<InventoryItem> Delete(long id)
        {
            var existing = _inventoryItems.First(a => a.Id == id);
            _inventoryItems.Remove(existing);
            return existing;
        }

        public async Task<InventoryItem> Get(long id)
        {
            return _inventoryItems.Where(a => a.Id == id)
           .FirstOrDefault();
        }

        public async Task<IEnumerable<InventoryItem>> GetAll()
        {
            return   _inventoryItems;
        }

        public Task<InventoryItem> Update(InventoryItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
