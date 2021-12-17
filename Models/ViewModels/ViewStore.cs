using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ViewStore
    {

        //public Store()
        //{
        //    Orders = new HashSet<Order>();
        //    ProductStores = new HashSet<ProductStore>();
        //}

        public int StoreId { get; set; }
        public string Address { get; set; }

        //all orders placed at the store
        public virtual ICollection<Order> Orders { get; set; }

        //inventory
        public virtual ICollection<ProductStore> ProductStores { get; set; }
    }
}
