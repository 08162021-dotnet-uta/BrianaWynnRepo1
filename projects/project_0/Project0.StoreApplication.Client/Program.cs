using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using System.Linq;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Client.Singletons;


namespace Project0.StoreApplication.Client

{
  class Program
  {

    // private Program p = new Program();
    private static readonly StoreSingleton singleton1 = StoreSingleton.GetStoreSingletonInstance();
    static void Main(string[] args)
    {
      //var singleton1 = StoreSingleton.GetStoreSingletonInstance();
      singleton1.PrintStoreNames();
      singleton1.PrintSelected();


    }
  }
}





// public static List<Store> createStores()
// {
//   // create a store collection
//   List<Store> stores = new List<Store>(); //I believe this should actually be a list of store objects not string
//   stores.Add(new Store());
//   stores.Add(new Store());
//   stores.Add(new Store());
//   return stores;
// }

//     public static List<Store> storeOutput()
//     {
//       //view store locations
//       //print store location to console

//       //get the repository and stores from it
//       StoreRepository allStores = new StoreRepository();
//       List<Store> storeList = new List<Store>();

//       foreach (var store in allStores.Stores)
//       {
//         Console.WriteLine(store.Name);
//         storeList.Add(store);

//       }
//       return storeList;
//     }

//     public static int CaptureInput()
//     {
//       //storeOutput();

//       //select one of the presented stores
//       //read the user input
//       Console.WriteLine("Make a selection");
//       var selected = int.Parse(Console.ReadLine()) - 1;

//       return selected;
//     }

//     public static void PrintSelected()
//     {

//       //confirm user selection
//       Console.WriteLine("You selected: " + storeOutput()[CaptureInput()].Name);

//     }

//     public static void AvailableProducts()
//     {
//       //check the availability of products before printing
//     }

//     public static List<Product> PrintProducts()
//     {
//       //print out the list of available products
//       ProductRepository allProducts = new ProductRepository();
//       List<Product> productList = new List<Product>();

//       Console.WriteLine("Here are the available products at this store: ");

//       foreach (var product in allProducts.products)
//       {
//         Console.WriteLine(product.Name);
//         productList.Add(product);

//       }
//       return productList;

//     }
