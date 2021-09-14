using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIDemoDataAcess.EntityModels
{
    public partial class ProductOrder
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
