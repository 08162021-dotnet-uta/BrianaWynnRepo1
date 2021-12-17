using System;
using System.Collections.Generic;

#nullable disable

namespace Models.EntityModels
{
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
