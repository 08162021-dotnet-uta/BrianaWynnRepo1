using System;
using Project0.StoreApplication.Storage.Repositories;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Singletons
{

  public class CustomerSingleton
  {

    private CustomerSingleton()
    {

      //private constructor for what point?
    }

    private static CustomerSingleton _customerSingletonInstance = null;

    private static readonly CustomerRepository _customerRepoInstance = CustomerRepository.GetCustomerRepositoryInstance();

    public static CustomerSingleton GetCustomerSingletonInstance()
    {

      if (_customerSingletonInstance == null)
      {

        _customerSingletonInstance = new CustomerSingleton();
      }
      return _customerSingletonInstance;

    }

    public void PrintCustomerNames()
    {
      List<String> newStrings = _customerSingletonInstance.ConvertCustomers();
      foreach (var index in newStrings)
      {
        Console.WriteLine(index);
      }


    }
    public string ReadSpecificCustomerName(Customer customer)
    {

      return customer.Name;
    }

    public void InitialWrite()
    {
      _customerRepoInstance.InitialWriteToFile();

    }

    public List<String> ConvertCustomers()
    {
      List<String> storeList = new List<string>();
      foreach (var store in _customerRepoInstance.ReadAllCustomers())
      {
        storeList.Add(store.Name);
      }
      return storeList;
    }

    public int CaptureInput()
    {
      //storeOutput();

      //select one of the presented stores
      //read the user input
      Console.WriteLine("Make a selection");
      var selected = int.Parse(Console.ReadLine()) - 1;

      return selected;
    }

    public void PrintSelectedCustomer()
    {

      //confirm user selection
      Console.WriteLine("You selected: " + _customerRepoInstance.SelectCustomerName(_customerSingletonInstance.CaptureInput()));

    }






  }


}