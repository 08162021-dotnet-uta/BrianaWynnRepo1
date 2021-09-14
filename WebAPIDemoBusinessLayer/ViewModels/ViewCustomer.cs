using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.Validation;

namespace WebAPIDemoBusinessLayer.ViewModels
{
    public class ViewCustomer
    {
        private CustomerRepository _testRepo = new CustomerRepository();
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PWord { get; set; }
        public long? CardNumber { get; set; }

       
        ICustomerValidation _validation;

        public ViewCustomer(ICustomerValidation custVal)
        {
            _validation = custVal;
        }

        public ViewCustomer()
        {
            _validation = new CustomerValidation();
        }


        public List<ViewCustomer> formatCustomers()
        {
            var entityCustomers = _testRepo.GetCustomers();
            List<ViewCustomer> formattedCustomers = new List<ViewCustomer>();
           

            for (int i = 0; i < entityCustomers.Count; i++)
            {
                formattedCustomers.Add(new ViewCustomer());
            }

            //set visible properties of the viewCustomer
            for (int i = 0; i < formattedCustomers.Count; i++)
            {
                formattedCustomers[i].FirstName = entityCustomers[i].FirstName;
                formattedCustomers[i].LastName = entityCustomers[i].LastName;
            }

            return formattedCustomers;
        }


    }//EOC
}//EON
