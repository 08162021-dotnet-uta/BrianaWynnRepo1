using System;
using System.Collections.Generic;

#nullable disable

namespace Models.EntityModels
{
    public partial class ProductStore
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }

        public int CurrentQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
