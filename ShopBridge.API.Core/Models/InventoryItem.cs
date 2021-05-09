using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopBridge.API.Core.Models
{
    public class InventoryItem : BaseClass
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Item Name required")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
    }
}
