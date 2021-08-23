using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
    public List<Product> products { get; }
    public ProductRepository()
    {
      // create a store collection
      Product exPack = new Product();
      Product dmVal = new Product();
      Product sg = new Product();

      exPack.Sku = 034950;

      exPack.Name = "Beyond the Vale - expansion pack";
      dmVal.Name = "Death March in Valmedia";
      sg.Name = "Starter's Guide";
      products = new List<Product>()
      {
        exPack,
        dmVal,
        sg

      };

    }


  }
}



