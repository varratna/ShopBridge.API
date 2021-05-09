using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.API.Core.Models
{
    public abstract class BaseClass
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
