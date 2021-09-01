using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project0.StoreApplication.Domain.Models
{
  public class Order
  {

    public Order()
        {

        }

    public Order(int oID, int cID, int sID, int pID)
        {
            OrderID = oID;
            CustomerID = cID;
            StoreID = sID;
            ProductID = pID;
            
        }
    public int  OrderID { get; set; }

       
    public int CustomerID{ get; set; }

    public int StoreID { get; set; }

    public int ProductID { get; set; }

   


    List<Product> productsInOrder = new List<Product>();

    //public void MaxProductInOrder(List<Product> productsInOrder)
    //{
    //    while (productsInOrder.Count < 2)
    //    {
    //        productsInOrder.Add(Product);
    //    }

    //}

    }

   
}