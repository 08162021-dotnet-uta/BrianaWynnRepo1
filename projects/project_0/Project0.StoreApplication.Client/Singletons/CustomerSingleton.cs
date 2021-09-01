using System;
using Project0.StoreApplication.Storage.Repositories;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// Customer Singleton Class
  /// </summary>  
  public class CustomerSingleton
  {
        /// <summary>
        /// private constructor for singleton design pattern
        /// </summary>
        private CustomerSingleton()
        {

      
        }

        private static CustomerSingleton _customerSingletonInstance = null;

        private static readonly CustomerRepository _customerRepoInstance = CustomerRepository.GetCustomerRepositoryInstance();
    
        /// <summary>
        /// returns customer singleton instance
        /// </summary>
        /// <returns></returns>
        public static CustomerSingleton GetCustomerSingletonInstance()
        {

          if (_customerSingletonInstance == null)
          {

            _customerSingletonInstance = new CustomerSingleton();
          }
          return _customerSingletonInstance;

        }

        /// <summary>
        /// prints the names of the customers onto the screen
        /// </summary>
        public void PrintCustomerNames()
        {
            int x = 1;
            List<String> newStrings = _customerSingletonInstance.ConvertCustomers();
            foreach (var index in newStrings)
            {
                Console.WriteLine(" [" + x + "] " + index);
                x++;
            }

        }
    
        /// <summary>
        /// returns a string with selected customer name
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public string ReadSpecificCustomerName(int customerKey)
        {

          return _customerRepoInstance.SelectCustomerName(customerKey);
        }
    
        /// <summary>
        // asks repo to write the initial preloaded customers to customer.xml file
        /// </summary>
        public void InitialWrite()
        {
          _customerRepoInstance.InitialWriteToFile();

        }
    
        /// <summary>
        /// returns a list of strings which are the customer names
        /// </summary>
        /// <returns></returns>
        public List<String> ConvertCustomers()
        {
          List<String> storeList = new List<string>();
          foreach (var store in _customerRepoInstance.ReadAllCustomers())
          {
            storeList.Add(store.Name);
          }
          return storeList;
        }

       /// <summary>
       /// captures the selected customer
       /// returns an int that can be used to index customer list
       /// </summary>
       /// <returns></returns>
        public int CaptureCustomerInput( )
        {
          int selected;
            
          Console.WriteLine("Who will be shopping with us today? \n");
          selected = int.Parse(Console.ReadLine()) - 1;

          return selected;
        }
    
        /// <summary>
        /// prints the selected customer to console
        /// </summary>
        /// <param name="s"></param>
        public void PrintSelectedCustomer(int s)
        {

          //confirm user selection
          Console.WriteLine("You selected: " + _customerRepoInstance.SelectCustomerName(s));

        }

        /// <summary>
        /// returns the customerid from file storage through customer repo instance
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        public int SelectedCustomerID(int customerKey)
        {
            return _customerRepoInstance.SelectCustomerID(customerKey);
        }

    }


}