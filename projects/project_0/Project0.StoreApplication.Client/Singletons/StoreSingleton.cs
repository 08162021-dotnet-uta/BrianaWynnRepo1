using System;
using Project0.StoreApplication.Storage.Repositories;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Singletons

{
  /// <summary>
  /// This class is a store singleton that will handle the logic needed by the client to access info
  /// about the stores
  /// </summary>
  public class StoreSingleton
  {

    // private static StoreSingleton _storeSingletonInstance = new StoreSingleton();
    // public static readonly StoreRepository storeRepo = StoreRepository.GetStoreRepoInstance();

    // public List<Store> Stores { get; private set; }

    private StoreSingleton()
    {
      //Stores = storeRepo.Stores;
    }

    private static StoreSingleton _storeSingletonInstance = null;
    private static readonly StoreRepository _storeRepoInstance = StoreRepository.GetStoreRepositoryInstance();
    /// <summary>
    /// Setup a store singleton that can access the store repository for retriving the stores. 
    /// The client program.cs should use this instance
    /// </summary>
    /// <returns></returns>
    public static StoreSingleton GetStoreSingletonInstance()
    {
      //   return _storeSingletonInstance;
      if (_storeSingletonInstance == null)
      {
        _storeSingletonInstance = new StoreSingleton();
      }
      return _storeSingletonInstance;
    }

    public List<String> ConvertStores()
    {
      //   foreach (var store in storeRepo.Stores)
      //   {
      //     Console.WriteLine(store.Name);
      //   }
      //Create a store
      List<String> storeList = new List<string>();
      foreach (var store in _storeRepoInstance.ReadAllStores())
      {
        storeList.Add(store.Name);
      }
      return storeList;
    }

    public void PrintStoreNames()
    {
      List<String> newStrings = _storeSingletonInstance.ConvertStores();
      foreach (var index in newStrings)
      {
        Console.WriteLine(index);
      }

    }
    /// <summary>
    /// This method is generic and should be moved to where anyone could call it
    /// </summary>
    /// <returns></returns>
    public int CaptureInput()
    {
      //storeOutput();

      //select one of the presented stores
      //read the user input
      Console.WriteLine("Make a selection");
      var selected = int.Parse(Console.ReadLine()) - 1;

      return selected;
    }

    public void PrintSelectedStore()
    {

      //confirm user selection
      Console.WriteLine("You selected: " + _storeRepoInstance.SelectStoreName(_storeSingletonInstance.CaptureInput()));

    }









  }
}