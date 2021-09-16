using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{
    public class CustomerRepository
    {
        CoreDbContext _dbContext = new CoreDbContext();
        public List<Customer> GetCustomers()
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<Customer> entityCustomers = _dbContext.Customers.FromSqlInterpolated($"SELECT * FROM CUSTOMERS").ToList();


            return entityCustomers;
        }

        public List<Order> GetStoreOrders()
        {
            List<Order> storeOrders = _dbContext.Orders.FromSqlInterpolated($"SELECT * FROM ORDERS WHERE storeId = 1").ToList();
            return storeOrders;
        }

        public void AddCustomer(Customer cust)
        {
            _dbContext.Customers.FromSqlInterpolated(
            $"INSERT INTO Customers(FirstName, LastName, email, pWord, cardNumber) Values({cust.FirstName},{cust.LastName},{cust.Email},{cust.PWord},null");
        }

        public int LoginCustomer(string email, string password)
        {
            Customer customer = _dbContext.Customers.FromSqlRaw($"Select * from customer where email = {email} and pWord = {password}").FirstOrDefault();

            if (customer == null)
            {

                return -1;
            }else
            {
                return customer.CustomerId;
            }
            
            
        }

        public Customer Register(Customer c)
        {
            //I added the person to the database
            _dbContext.Customers.FromSqlInterpolated($"insert into Customers (FirstName, LastName, email, pWord) values ({c.FirstName},{c.LastName},{c.Email},{c.PWord}");
            _dbContext.SaveChanges();

            //go and grab that same customer
            //no protection against duplicates
            Customer user = _dbContext.Customers.FromSqlInterpolated($"Select * from Customers where FirstName = {c.FirstName} and LastName = {c.LastName}").FirstOrDefault();
            return user;
        }
    }//eoc
}//eon
