using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoDataAcess.EntityModels
{
    public partial class Inventory
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }

        public int CurrentQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }


    }
}
