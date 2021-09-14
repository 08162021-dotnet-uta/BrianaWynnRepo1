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
    }
}
