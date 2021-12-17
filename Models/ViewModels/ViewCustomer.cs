using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ViewCustomer
    {

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PWord { get; set; }
        //public long? CardNumber { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

    }
}
