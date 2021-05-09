using ShopBridge.API.Core.Models;
using ShopBridge.API.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        private IUnitOfWork _unitOfWork;

        public InventoryItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<InventoryItem> Add(InventoryItem entity)
        {
            await _unitOfWork.inventoryItemRepository.Add(entity);
            await _unitOfWork.Save();
            return entity;
        }

        public async Task<InventoryItem> Delete(long id)
        {
            var item =await _unitOfWork.inventoryItemRepository.Delete(id);
            await _unitOfWork.Save();
            return item;
        }

        public async Task<InventoryItem> Get(long id)
        {
            var items = await _unitOfWork.inventoryItemRepository.Get(id);
            return items;
        }

        public async Task<IEnumerable<InventoryItem>> GetAll()
        {
            var items = await _unitOfWork.inventoryItemRepository.GetAll();
            return items.OrderByDescending(e => e.Id);
        }

        public async Task<InventoryItem> Update(InventoryItem entity)
        {
            var item = await _unitOfWork.inventoryItemRepository.Update(entity, entity.Id);
            await _unitOfWork.Save();
            return item;
        }
    }
}
