using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIDemoDataAcess.EntityModels
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            ProductStores = new HashSet<ProductStore>();
        }

        public int StoreId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
    }
}
