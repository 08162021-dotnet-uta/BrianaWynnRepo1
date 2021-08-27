using System;
using System.Collections.Generic;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Project0.StoreApplication.Storage.Repositories
{

  public class CustomerRepository
  {
    private static CustomerRepository _customerRepositoryInstance = null;
    private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();

    private static string _filePath = @"/home/briana/revature/briana_code/data/customer.xml";

    public static CustomerRepository GetCustomerRepositoryInstance()
    {

      if (_customerRepositoryInstance == null)
      {
        _customerRepositoryInstance = new CustomerRepository();
      }
      return _customerRepositoryInstance;
    }



    public CustomerRepository()
    {

    }

    public void InitialWriteToFile()
    {
      List<Customer> customers = _customerRepositoryInstance.CreateCustomers();
      _fa.WriteToFile<Customer>(customers, _filePath);

    }

    public void AddCustomer()
    {

    }

    public void DeleteCustomer()
    {

    }

    public List<Customer> ReadAllCustomers()
    {

      if (_fa.ReadFromFile<Customer>(_filePath) == null)
      {
        _fa.WriteToFile<Customer>(new List<Customer>(), _filePath);
      }

      return _fa.ReadFromFile<Customer>(_filePath);
    }

    public Customer ReadSpecificCustomer(int customerKey)
    {
      return _fa.ReadFromFile<Customer>(_filePath)[customerKey];
    }

    public string SelectCustomerName(int customerKey)
    {

      return ReadSpecificCustomer(customerKey).Name;
    }


    public List<Customer> CreateCustomers()
    {
      Customer customer1 = new Customer();
      Customer customer2 = new Customer();
      Customer customer3 = new Customer();

      customer1.Name = "Susan O'Boyle";
      customer2.Name = "Jeffry Jeffry";
      customer3.Name = "Winnie Wynn";

      List<Customer> customers = new List<Customer>(){
        customer1,
        customer2,
        customer3
      };

      return customers;
    }

    // private readonly DBAdapter _da = new DBAdapter();
    // public List<Customer> GetCustomers()
    // {
    //   return _da.Customers.FromSqlRaw("Select Name from Customer.Customer").ToList();
    // }



  }
}