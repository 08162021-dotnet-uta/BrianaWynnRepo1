using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoDataAcess.Repositories
{
    //Todo List:
        //1. Add Exception Handling
        //2. switch to async methods
        //3. add xml comments
    public class CustomerRepository
    {
        private readonly CoreDbContext _context;
        public CustomerRepository(CoreDbContext context)
        {
            
            _context = context;
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> entityCustomers = new List<Customer>();
            try
            {
                entityCustomers = _context.Customers.OrderBy(c => c.FirstName).ToList();
                    //_dbContext.Customers.FromSqlInterpolated($"SELECT * FROM CUSTOMERS").ToList();
            }
            catch(Exception ex)
            {
                entityCustomers = null;
            }

            return entityCustomers;
        }

       // public List<Order> GetStoreOrders()
        //{
        //    List<Order> storeOrders = _context.Orders.FromSqlInterpolated($"SELECT * FROM ORDERS WHERE storeId = 1").ToList();
        //    return storeOrders;
        //}

        public bool AddCustomer(Customer cust)
        {
            bool status;
            try
            {
                _context.Customers.Add(cust);
                _context.SaveChanges();
                status = true;
            }
            catch(Exception ex)
            {
                status = false;
            }
            return status;
        }

        public int LoginCustomer(Customer c)
        {
            //Todo switch this to an authentication system instead
            int status;
            try
            {
                Customer customer = _context.Customers.Find(c.CustomerId);
                if(customer != null && (customer.Email.Equals(c.Email) && customer.PWord.Equals(c.PWord)))
                {
                    status = 1;
                }
                else
                {
                    status = -99;
                }
            }
            catch(Exception ex)
            {
                status = -99;
            }
            return status;
            
        }

        public bool DeleteCustomer(Customer customer)
        {
            bool status;
            try
            {
                Customer removeCustomer = _context.Customers.Find(customer.CustomerId);

                if(removeCustomer.Email != null)
                {
                    _context.Customers.Remove(removeCustomer);
                    _context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public int UpdateCustomer(Customer customer)
        {
            int status;
            try
            {
                Customer cust = _context.Customers.Find(customer.CustomerId);
                if(cust.Email != null)
                {
                    cust.Email = customer.Email;
                    cust.FirstName = customer.FirstName;
                    cust.LastName = customer.LastName;
                    cust.PWord = customer.PWord;
                    _context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = -99;
                }
            }
            catch(Exception ex)
            {
                status = -99;
            }
            return status;
        }
    }//eoc
}//eon
