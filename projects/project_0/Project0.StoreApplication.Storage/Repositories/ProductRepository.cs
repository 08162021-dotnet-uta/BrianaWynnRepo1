using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
       
        private static ProductRepository _productRepoInstance = null;
        private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();

        private static readonly string _filePath = @"C:\Users\bnwyn\source\repos\08162021-dotnet-uta\BrianaWynnRepo1\projects\project_0\data\product.xml";

        /// <summary>
        /// Returns an instance of product repository
        /// </summary>
        /// <returns></returns>
        public static ProductRepository GetProductRepositoryInstance()
        {
          if (_productRepoInstance == null)
          {
            _productRepoInstance = new ProductRepository();
          }
          return _productRepoInstance;
        }

        /// <summary>
        /// Generates a list of products that are available at each store
        /// Initializes name, price, and id
        /// </summary>
        /// <returns></returns>
        public List<Product> CreateProducts()
        {
          // create a store collection
          Product exPack = new Product();
          Product dmVal = new Product();
          Product sg = new Product();
                  
          exPack.Name = "Beyond the Vale - expansion pack";
          dmVal.Name = "Death March in Valmedia";
          sg.Name = "Starter's Guide";

          exPack.Price = 10.25;
          dmVal.Price = 40.97;
          sg.Price = 25.25;

          exPack.ProductID = 1;
          dmVal.ProductID = 2;
          sg.ProductID = 3;

          List<Product> products = new List<Product>()
          {
                exPack,
                dmVal,
                sg

          };
          return products;

        }

        /// <summary>
        /// Read all products from product.xml file
        /// This will return a list of products
        /// </summary>
        /// <returns></returns>
        public List<Product> ReadAllProducts()
        {

          if (_fa.ReadFromFile<Product>(_filePath) == null)
          {
            _fa.WriteToFile<Product>(new List<Product>(), _filePath);
          }

          return _fa.ReadFromFile<Product>(_filePath);
        }
    
        /// <summary>
        /// Creates the file with the preloaded products
        /// </summary>
        public void InitialWriteToFile()
        {
          List<Product> products = _productRepoInstance.CreateProducts();
          _fa.WriteToFile<Product>(products, _filePath);

        }

        /// <summary>
        /// Returns a specific product when given the product index
        /// </summary>
        /// <param name="productKey"></param>
        /// <returns></returns>
        public Product ReadSpecificProduct(int productKey)
        {
          return _fa.ReadFromFile<Product>(_filePath)[productKey];
        }


        /// <summary>
        /// returns a string with the product name for a specific product when given the product index
        /// </summary>
        /// <param name="productKey"></param>
        /// <returns></returns>
        public string SelectProductName(int productKey)
        {

          return ReadSpecificProduct(productKey).Name;
        }
    
        /// <summary>
        /// returns a double of product price when given the product index
        /// </summary>
        /// <param name="productKey"></param>
        /// <returns></returns>
        public double SelectProductPrice(int productKey)
        {

          return ReadSpecificProduct(productKey).Price;
        }

    }
}



