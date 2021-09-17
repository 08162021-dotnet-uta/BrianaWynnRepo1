using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Mappers
{
    public class CustomerMapper: ICustomerMapper
    {
        

        public ViewCustomer CustomerToViewCustomer(Customer c)
        {
            //get a customer from the repo
            //match all the properties 1 to 1 with a view 
            //make a new vm

            ViewCustomer vc = new ViewCustomer();
            //vc.CardNumber = c.CardNumber;
            vc.Email = c.Email;
            vc.FirstName = c.FirstName;
            vc.LastName = c.LastName;
            vc.PWord = c.PWord;
            vc.CustomerId = c.CustomerId;

            return vc;

        }

        public Customer ViewCustomerToCustomer(ViewCustomer c)
        {
            //get a customer from the repo
            //match all the properties 1 to 1 with a view 
            //make a new vm

            Customer c1 = new Customer();
            c1.LastName = c.LastName;
            c1.FirstName = c.FirstName;
            c1.Email = c.Email;
            c1.CustomerId = (int) c.CustomerId;
            c1.PWord = c.PWord;

            return c1;

        }


    }
}
