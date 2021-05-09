using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Core.Models;
using ShopBridge.API.Core.Services;
using ShopBridge.API.ViewModel;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private IInventoryItemService _inventoryItemService;
        IList<InventoryItem> invItem = new List<InventoryItem>();
        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id)
        {
            try
            {
                var item = await _inventoryItemService.Get(Id);
                if (item != null)
                {
                    invItem.Add(item);
                    return Ok(GetInventoryItemViewModel(invItem).FirstOrDefault());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _inventoryItemService.GetAll();
                return Ok(GetInventoryItemViewModel(items));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventoryItem item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    item = await _inventoryItemService.Add(item);

                    if (item.Id != 0)
                    {
                        invItem.Add(item);
                        return Ok(GetInventoryItemViewModel(invItem).FirstOrDefault());
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }

            return BadRequest();

        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InventoryItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedItem = await _inventoryItemService.Update(item);

                    return Ok(updatedItem);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            long result = 0;

            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var item = await _inventoryItemService.Delete(id);
                return Ok("Item with ID " + id + " deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        private List<InventoryItemViewModel> GetInventoryItemViewModel(IEnumerable<InventoryItem> items)
        {
            List<InventoryItemViewModel> lstItems = new List<InventoryItemViewModel>();
            foreach (var item in items)
            {
                InventoryItemViewModel inventoryItemvm = new InventoryItemViewModel();
                inventoryItemvm.Id = item.Id;
                inventoryItemvm.Name = item.Name;
                inventoryItemvm.Price = item.Price;
                inventoryItemvm.Manufacturer = item.Manufacturer;

                lstItems.Add(inventoryItemvm);
            }
            return lstItems;
        }
    }
}
