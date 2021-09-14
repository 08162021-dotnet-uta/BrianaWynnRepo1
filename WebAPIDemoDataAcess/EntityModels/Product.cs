using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIDemoDataAcess.EntityModels
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
            ProductStores = new HashSet<ProductStore>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
    }
}
