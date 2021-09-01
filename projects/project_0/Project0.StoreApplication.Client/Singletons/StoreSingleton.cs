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
    /// <summary>
    /// private constructor for singleton design pattern
    /// </summary>
    private StoreSingleton()
    {
      
    }

    private static StoreSingleton _storeSingletonInstance = null;
    private static readonly StoreRepository _storeRepoInstance = StoreRepository.GetStoreRepositoryInstance();
   
    /// <summary>
    /// returns the instance of storeSingleton that's available
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
    
    /// <summary>
    /// returns a list of strings which are the names of the stores
    /// </summary>
    /// <returns></returns>
    public List<String> ConvertStores()
    {
      List<String> storeList = new List<string>();
      foreach (var store in _storeRepoInstance.ReadAllStores())
      {
        storeList.Add(store.Name);
      }
      return storeList;
    }
    /// <summary>
    /// Print the names of the stores
    /// uses the ConvertStores() method
    /// </summary>
    public void PrintStoreNames()
    {
      List<String> newStrings = _storeSingletonInstance.ConvertStores();
      foreach (var index in newStrings)
      {
        Console.WriteLine(index);
      }

    }
    /// <summary>
    /// Alerts the user to make a selection
    /// returns selection -1 as an integer
    /// selection is meant for indexing into list
    /// </summary>
    /// <returns></returns>
    public int CaptureStoreInput()
    {
      //storeOutput();

      //select one of the presented stores
      //read the user input
      Console.WriteLine("Make a selection");
      var selected = int.Parse(Console.ReadLine()) - 1;

      return selected;
    }

    /// <summary>
    /// prints the selected store
    /// </summary>
    /// <param name="s"></param>
    public void PrintSelectedStore(int s)
    {

      //confirm user selection
      Console.WriteLine("You selected: " + _storeRepoInstance.SelectStoreName(s));

    }
        /// <summary>
        /// initial write to store.xml to preload available stores
        /// </summary>
        public void InitialWrite()
        {
            _storeRepoInstance.InitialWriteToFile();

        }

        /// <summary>
        /// returns store id from file storage through store repository instance
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>

        public int SelectedStoreID(int storeKey)
        {
            return _storeRepoInstance.SelectStoreID(storeKey);
        }

        /// <summary>
        /// returns a selected store name from file storage through store repository
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>
        public string GetStoreName(int storeKey)
        {
            return _storeRepoInstance.SelectStoreName(storeKey);
        }

    }
}