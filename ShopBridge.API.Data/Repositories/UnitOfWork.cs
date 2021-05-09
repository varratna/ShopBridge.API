using ShopBridge.API.Core.Repositories;
using ShopBridge.API.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {
        private readonly InventoryContext _context;
        private IInventoryItemRepository _inventoryItemRepository;

        public UnitOfWork(InventoryContext context)
        {
            _context = context;
        }        

        public IInventoryItemRepository inventoryItemRepository
        {
            get { return _inventoryItemRepository ?? (_inventoryItemRepository = new InventoryRepository(_context)); }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

    }


}
