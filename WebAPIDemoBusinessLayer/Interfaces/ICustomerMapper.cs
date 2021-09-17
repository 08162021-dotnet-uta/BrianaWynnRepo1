using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Interfaces
{
    public interface ICustomerMapper
    {
        public ViewCustomer CustomerToViewCustomer(Customer c);



        public Customer ViewCustomerToCustomer(ViewCustomer c);
        
          
        
    }
}
