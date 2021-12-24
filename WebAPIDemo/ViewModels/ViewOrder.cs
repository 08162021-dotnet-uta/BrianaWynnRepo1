using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemo.ViewModels
{
    public class ViewOrder
    {
        public ViewOrder()
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
