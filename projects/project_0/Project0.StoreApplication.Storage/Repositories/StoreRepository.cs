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
        private static string _filePath = @"C:\Users\bnwyn\source\repos\08162021-dotnet-uta\BrianaWynnRepo1\projects\project_0\data\store.xml";
    
        /// <summary>
        /// a private constructor for singleton design pattern
        /// </summary>
        private StoreRepository()
        {

        }

        /// <summary>
        /// returns a store repostiory instance
        /// </summary>
        /// <returns></returns>
        public static StoreRepository GetStoreRepositoryInstance()
        {

            if (_storeRepoInstance == null)
            {
            _storeRepoInstance = new StoreRepository();
            }
            return _storeRepoInstance;
        }
        /// <summary>
        /// read all stores from store.xml file
        /// </summary>
        /// <returns></returns>
        public List<Store> ReadAllStores()
        {
          //read the stores from the file and return a list of stores to whatever calls it
          //what if the store.xml is blank
          if (_fa.ReadFromFile<Store>(_filePath) == null)
          {
           _fa.WriteToFile<Store>(new List<Store>(), _filePath);
          }

          return _fa.ReadFromFile<Store>(_filePath);
        }

        /// <summary>
        /// Allows the user to select the Store
        /// </summary>
        public Store Select(int storeKey)
        {

          return _fa.ReadFromFile<Store>(_filePath)[storeKey];
        }
    
        /// <summary>
        /// returns a string with specific store name from store.xml file
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>
        public string SelectStoreName(int storeKey)
        {

          return _fa.ReadFromFile<Store>(_filePath)[storeKey].Name;
        }
        /// <summary>
        /// returns a byte with specified store id
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>
        public byte SelectStoreID(int storeKey)
        {
            return Select(storeKey).StoreID;
        }
        /// <summary>
        /// creates the initial stores that are preloaded to the store.xml file
        /// </summary>
        /// <returns></returns>
        public List<Store> CreateStores()
        {
          //create the list of stores
          // create a store collection
          Store a = new Store();
          Store b = new Store();
          Store c = new Store();

          a.Location = "312 Penn";

          a.Name = "Sword & Spell - Martinville";
          b.Name = "Sword & Spell - Liesburg";
          c.Name = "Sword & Spell - Gatlyn";

          a.StoreID = 1;
          b.StoreID = 2;
          c.StoreID = 3;

          List<Store> Stores = new List<Store>() { a, b, c };

          return Stores;
        }
        /// <summary>
        /// runs the initial write to file to preload the stores into the store.xml file
        /// </summary>
        public void InitialWriteToFile()
        {
            List<Store> stores = _storeRepoInstance.CreateStores();
            _fa.WriteToFile<Store>(stores, _filePath);

        }



    }


}




