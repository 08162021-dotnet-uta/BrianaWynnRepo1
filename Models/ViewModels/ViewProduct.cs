using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ViewProduct
    {
        //public Product()
        //{
        //    ProductOrders = new HashSet<ProductOrder>();
        //    ProductStores = new HashSet<ProductStore>();
        //}

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
    }
}
