using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemo.ViewModels
{
    public class ViewStore
    {

        public ViewStore()
        {
            this.Name = "Sword & Spell";
            Orders = new HashSet<Order>();
            ProductStores = new HashSet<ProductStore>();
        }
        public int StoreId { get; set; }
        public string Address { get; set; }

        public string Name { get; private set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
    }
}
