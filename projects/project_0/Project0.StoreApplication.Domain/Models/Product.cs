using System;

namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public string Name { get; set; }

    public int ProductID { get; set; }

    public int Quantity { get; set; }// to check for availability before displaying to the customer

    public double Price { get; set; }


  }
}

