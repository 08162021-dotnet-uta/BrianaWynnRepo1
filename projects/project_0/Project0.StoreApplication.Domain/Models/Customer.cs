using System;
using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{

  public class Customer
  {
    public int CustomerID { get; set; }
    public string Name { get; set; }

    public List<Order> orders { get; set; }


  }










}