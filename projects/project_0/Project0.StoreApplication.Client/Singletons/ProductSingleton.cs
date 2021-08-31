using System;
using Project0.StoreApplication.Storage.Repositories;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Singletons

{
  /// <summary>
  /// Product singleton class 
  /// </summary>
  public class ProductSingleton
  {
        /// <summary>
        /// private constructor for singleton design pattern
        /// </summary>
        private ProductSingleton()
        {
      
        }

        private static ProductSingleton _ProductSingletonInstance = null;
        private static readonly ProductRepository _productRepoInstance = ProductRepository.GetProductRepositoryInstance();
    
        /// <summary>
        /// returns productsingleton instance
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
        /// returns the name of the products as list of string from the product list
        /// </summary>
        /// <returns></returns>
        public List<String> ConvertProducts()
        {    
          List<String> productList = new List<string>();
          foreach (var product in _productRepoInstance.ReadAllProducts())
          {
            productList.Add(product.Name);
          }
          return productList;
        }
    
         /// <summary>
         /// print product names using return from convertProducts
         /// </summary>
        public void PrintProductNames()
        {
          List<String> newStrings = _ProductSingletonInstance.ConvertProducts();
          foreach (var index in newStrings)
          {
            Console.WriteLine(index);
          }

        }
        /// <summary>
        /// captures the selected product from the user
        /// returns int selected which is used for indexing list
        /// </summary>
        /// <returns></returns>
        public int CaptureProductInput()
        {
          //storeOutput();

          //select one of the presented stores
          //read the user input
          Console.WriteLine("\n What would you like to buy today?");
          var selected = int.Parse(Console.ReadLine()) - 1;

          return selected;
        }
    
        /// <summary>
        /// prints selected produt
        /// </summary>
        /// <param name="s"></param>
        public void PrintSelectedProduct(int s)
        {

          //confirm user selection
     
          Console.WriteLine("You selected: " + _productRepoInstance.SelectProductName(s) + " Price: $" + _productRepoInstance.SelectProductPrice(s));

        }
    
        /// <summary>
        /// initial write to file calls to repository instance to write
        /// 
        /// </summary>
        public void InitialWrite()
        {
          _productRepoInstance.InitialWriteToFile();

        }
    
        /// <summary>
        /// returns a string with a specified product name
        /// productKey is the desired index in product list
        /// </summary>
        /// <param name="productKey"></param>
        /// <returns></returns>
        public string GetProductName(int productKey)
        {
            return _productRepoInstance.SelectProductName( productKey);
        }
    
        /// <summary>
        /// Asks customer to confirm that they would like to purchase the product
        /// returns a bool that is used in Add Order
        /// </summary>
        /// <returns></returns>
        public bool ConfirmPurchase()
        {
          Console.WriteLine("Would you like to continue with your order? Enter y for yes and n for no");
                if(Equals(Console.ReadLine(), "y")){
                    return true;
                }

                return false;
        }
            
        /// <summary>
        /// asks the product repository instance to grab a specific product 
        /// </summary>
        /// <param name="ProductKey"></param>
        /// <returns></returns>
        public byte SelectedProductID(int ProductKey)
        {
            return _productRepoInstance.ReadSpecificProduct(ProductKey).ProductID;
        }

    }
}