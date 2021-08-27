using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;


namespace Project0.StoreApplication.Storage.Repositories
{ /// <summary>
  /// Store Repository class creates a list of available locations
  /// </summary>
  public class StoreRepository
  {
    private static StoreRepository _storeRepoInstance = null;
    private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();
    public static StoreRepository GetStoreRepositoryInstance()
    {

      if (_storeRepoInstance == null)
      {
        _storeRepoInstance = new StoreRepository();
      }
      return _storeRepoInstance;
    }

    // public List<Store> Stores { get; set; }
    // //List<Store> Stores = new List<Store>();
    // private static StoreRepository _instance = new StoreRepository();

    private static string _filePath = @"/home/briana/revature/briana_code/data/store.xml";
    // private static readonly FileAdapter _fa = new FileAdapter();
    /// <summary>
    /// Initializes the store repository and creates stores to be added to the xml file if the file does not already contain stores
    /// </summary>


    public StoreRepository()
    {

    }

    public List<Store> ReadAllStores()
    {
      //read the stores from the file and return a list of stores to whatever calls it
      //what if the store.xml is blank
      if (_fa.ReadFromFile<Store>(_filePath) == null)
      {
        //List<Store> storeList = StoreRepository.GetStoreStoreRepositoryInstance().CreateStores();

        _fa.WriteToFile<Store>(new List<Store>(), _filePath);
      }



      return _fa.ReadFromFile<Store>(_filePath);
    }

    // public void AddStore()
    // {
    //   _fa.WriteToFile<Store>()
    // }


    /// <summary>
    /// Allows the user to select the Store
    /// </summary>
    public Store Select(int storeKey)
    {

      return _fa.ReadFromFile<Store>(_filePath)[storeKey];
    }

    public string SelectStoreName(int storeKey)
    {

      return _fa.ReadFromFile<Store>(_filePath)[storeKey].Name;
    }
    // /// <summary>
    // /// Allows for adding a new store. Only the company should have access to this. Definitely not for the client
    // /// </summary>
    // private void Add()
    // {
    //   //add the store to the list

    //   //check if the file exists and delete

    //   //rewrite the file with the new store
    // }

    /// <summary>
    /// Allows for deleting a store from storage
    /// </summary>
    // private void Delete()
    // {
    //   //remove the store from the list

    //   //delete the existing file

    //   //overwrite the file without the store

    // }

    /// <summary>
    /// Creates a repository singleton
    /// </summary>
    /// <returns></returns>
    // public static StoreRepository GetStoreRepoInstance()
    // {

    //   return _instance;
    // }

    public List<Store> CreateStores()
    {
      //create the list of stores
      // create a store collection
      Store a = new Store();
      Store b = new Store();
      Store c = new Store();

      a.Location = "312 Penn";

      a.Name = "Aldi";
      b.Name = "Sams";
      c.Name = "Bills";
      List<Store> Stores = new List<Store>() { a, b, c };

      return Stores;
    }



  }


}




