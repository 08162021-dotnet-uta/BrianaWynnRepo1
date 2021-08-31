using System;
using System.Collections.Generic;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project0.StoreApplication.Storage.Repositories
{

  public class CustomerRepository
  {
    private static CustomerRepository _customerRepositoryInstance = null;
    private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();
    private static readonly DBAdapter _da = new DBAdapter();

    private static string _filePath = @"C:\Users\bnwyn\Source\Repos\08162021-dotnet-uta\BrianaWynnRepo1\projects\project_0\data\customer.xml";

        /// <summary>
        /// private constructor for singleton design pattern
        /// </summary>
        private CustomerRepository()
        {

        }

        /// <summary>
        /// returns instance of customer repository
        /// </summary>
        /// <returns></returns>
        /// 
        public static CustomerRepository GetCustomerRepositoryInstance()
        {

            if (_customerRepositoryInstance == null)
            {
            _customerRepositoryInstance = new CustomerRepository();
            }
            return _customerRepositoryInstance;
        }


        /// <summary>
        /// Repository writes preloaded customer list to customer.xml
        /// </summary>
   
        public void InitialWriteToFile()
        {
            List<Customer> customers = _customerRepositoryInstance.CreateCustomers();
            _fa.WriteToFile<Customer>(customers, _filePath);

        }
        /// <summary>
        /// adds a new customer to customer list and writes to customer.xml
        /// non-functioning
        /// </summary>
        public void AddCustomer()
        {

        }

        /// <summary>
        /// deletes a customer from the current list and rewrites the file
        /// non-functioning
        /// </summary>
        public void DeleteCustomer()
        {

        }
        /// <summary>
        /// reads all customers from customer.xml file
        /// </summary>
        /// <returns></returns>
        public List<Customer> ReadAllCustomers()
        {

          if (_fa.ReadFromFile<Customer>(_filePath) == null)
          {
            _fa.WriteToFile<Customer>(new List<Customer>(), _filePath);
          }

          return _fa.ReadFromFile<Customer>(_filePath);
        }

        /// <summary>
        /// returns a specified customer from the customer.xml file
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        public Customer ReadSpecificCustomer(int customerKey)
        {
          return _fa.ReadFromFile<Customer>(_filePath)[customerKey];
        }
        
        /// <summary>
        /// returns a string of customer name from the customer.xml file
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        public string SelectCustomerName(int customerKey)
        {

          return ReadSpecificCustomer(customerKey).Name;
        }
        /// <summary>
        /// returns byte with customer id from the customer.xml file
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        public byte SelectCustomerID(int customerKey)
        {
            return ReadSpecificCustomer(customerKey).CustomerID;
        }

        /// <summary>
        /// creates the initial list of customers 
        /// initializes customerid, name
        /// returns the list of customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> CreateCustomers()
        {
          Customer customer1 = new Customer();
          Customer customer2 = new Customer();
          Customer customer3 = new Customer();

          customer1.Name = "Susan O'Boyle";
          customer2.Name = "Jeffry Jeffry";
          customer3.Name = "Winnie Wynn";

          customer1.CustomerID = 1;
          customer2.CustomerID = 2;
          customer3.CustomerID = 3;

          List<Customer> customers = new List<Customer>(){
            customer1,
            customer2,
            customer3
          };

            return customers;
        }

  }
}