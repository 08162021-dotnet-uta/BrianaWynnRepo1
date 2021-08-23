using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    public List<Store> Stores { get; }
    public StoreRepository()
    {
      // create a store collection
      Store a = new Store();
      Store b = new Store();
      Store c = new Store();

      a.Location = "312 Penn";

      a.Name = "Aldi";
      b.Name = "Sams";
      c.Name = "Bills";
      Stores = new List<Store>()
      {
        a,b,c

      };

    }


  }
}



