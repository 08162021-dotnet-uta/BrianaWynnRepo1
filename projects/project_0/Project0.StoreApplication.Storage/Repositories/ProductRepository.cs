using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
    //public List<Product> products { get; }
    private static ProductRepository _productRepoInstance = null;
    private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();

    private static readonly string _filePath = @"/home/briana/revature/briana_code/data/product.xml";
    public static ProductRepository GetProductRepositoryInstance()
    {
      if (_productRepoInstance == null)
      {
        _productRepoInstance = new ProductRepository();
      }
      return _productRepoInstance;
    }
    public List<Product> CreateProducts()
    {
      // create a store collection
      Product exPack = new Product();
      Product dmVal = new Product();
      Product sg = new Product();

      exPack.Sku = 034950;

      exPack.Name = "Beyond the Vale - expansion pack";
      dmVal.Name = "Death March in Valmedia";
      sg.Name = "Starter's Guide";

      exPack.Price = 10.25;
      dmVal.Price = 40.97;
      sg.Price = 25.25;

      List<Product> products = new List<Product>()
      {
        exPack,
        dmVal,
        sg

      };
      return products;

    }

    public List<Product> ReadAllProducts()
    {

      if (_fa.ReadFromFile<Product>(_filePath) == null)
      {
        _fa.WriteToFile<Product>(new List<Product>(), _filePath);
      }

      return _fa.ReadFromFile<Product>(_filePath);
    }

    public void InitialWriteToFile()
    {
      List<Product> products = _productRepoInstance.CreateProducts();
      _fa.WriteToFile<Product>(products, _filePath);

    }

    public Product ReadSpecificProduct(int productKey)
    {
      return _fa.ReadFromFile<Product>(_filePath)[productKey];
    }

    public string SelectProductName(int productKey)
    {

      return ReadSpecificProduct(productKey).Name;
    }

    public double SelectProductPrice(int productKey)
    {

      return ReadSpecificProduct(productKey).Price;
    }





  }
}



