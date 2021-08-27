using System;
using Project0.StoreApplication.Storage.Repositories;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Singletons

{
  /// <summary>
  /// 
  /// </summary>
  public class ProductSingleton
  {

    //private static ProductSingleton _ProductSingletonInstance = new ProductSingleton();
    //public static readonly StoreRepository storeRepo = StoreRepository.GetStoreRepoInstance();

    // public List<Store> Stores { get; private set; }

    private ProductSingleton()
    {
      //Stores = storeRepo.Stores;
    }

    private static ProductSingleton _ProductSingletonInstance = null;
    private static readonly ProductRepository _productRepoInstance = ProductRepository.GetProductRepositoryInstance();
    /// <summary>
    /// Setup a product singleton that can access the store repository for retriving the stores. 
    /// The client program.cs should use this instance
    /// </summary>
    /// <returns></returns>
    public static ProductSingleton GetProductSingletonInstance()
    {
      //   return _ProductSingletonInstance;
      if (_ProductSingletonInstance == null)
      {
        _ProductSingletonInstance = new ProductSingleton();
      }
      return _ProductSingletonInstance;
    }

    /// <summary>
    /// returns the name of the products from the product list
    /// </summary>
    /// <returns></returns>
    public List<String> ConvertProducts()
    {
      //   foreach (var product in storeRepo.Stores)
      //   {
      //     Console.WriteLine(store.Name);
      //   }
      //Create a store
      List<String> productList = new List<string>();
      foreach (var product in _productRepoInstance.ReadAllProducts())
      {
        productList.Add(product.Name);
      }
      return productList;
    }

    public void PrintProductNames()
    {
      List<String> newStrings = _ProductSingletonInstance.ConvertProducts();
      foreach (var index in newStrings)
      {
        Console.WriteLine(index);
      }

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
    public void PrintSelectedProduct()
    {

      //confirm user selection
      var selected = _ProductSingletonInstance.CaptureInput();
      Console.WriteLine("You selected: " + _productRepoInstance.SelectProductName(selected) + " Price: $" + _productRepoInstance.SelectProductPrice(selected));

    }

    public void InitialWrite()
    {
      _productRepoInstance.InitialWriteToFile();

    }

    public string ConfirmPurchase()
    {
      Console.WriteLine("Would you like to continue with your order? Enter y for yes and n for no");
      return Console.ReadLine();
    }

    public void ContinuePurchase()
    {
      if (Equals(_ProductSingletonInstance.ConfirmPurchase(), "y"))
      {
        //grab customer number
        //grab product number
        //grab store number
        //create a new order
        //save the order
        Console.WriteLine("Thank you for your purchase");


      }
    }







  }
}