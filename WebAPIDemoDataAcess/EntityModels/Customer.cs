using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIDemoDataAcess.EntityModels
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PWord { get; set; }
        public long? CardNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
