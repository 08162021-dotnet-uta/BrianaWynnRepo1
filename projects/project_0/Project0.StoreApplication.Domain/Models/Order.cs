using System;
using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Order
  {
    public int OrderID { get; set; }

    public Customer buyer { get; set; }

    public List<Product> products { get; set; }


  }
}