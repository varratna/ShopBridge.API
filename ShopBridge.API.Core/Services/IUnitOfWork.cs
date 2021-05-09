using ShopBridge.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Core.Services
{
    public interface IUnitOfWork
    {
        IInventoryItemRepository inventoryItemRepository { get; }
        Task Save();
    }
}
