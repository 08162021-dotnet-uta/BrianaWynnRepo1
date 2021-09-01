using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using System;
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Singletons
{   /// <summary>
    /// The order singleton class
    /// </summary>
    public class OrderSingleton
    {   /// <summary>
        /// private constructor for singleton design pattern
        /// </summary>
        private OrderSingleton()
        {
        
        }

        private static OrderSingleton _orderSingletonInstance = null;
        private static readonly OrderRepository _orderRepoInstance = OrderRepository.GetOrderRepositoryInstance();

        /// <summary>
        /// Returns the instance of Ordersingleton
        /// </summary>
        /// <returns></returns>
        public static OrderSingleton GetOrderSingletonInstance()
        {
            //   return _ProductSingletonInstance;
            if (_orderSingletonInstance == null)
            {
                _orderSingletonInstance = new OrderSingleton();
            }
            return _orderSingletonInstance;
        }
        /// <summary>
        /// Creates an order after customer confirmation
        /// Boolean buy ==true means customer confirmed and wants to create the order
        /// </summary>
        /// <param name="buy"></param>
        /// <param name="sID"></param>
        /// <param name="pID"></param>
        /// <param name="cID"></param>
        /// <returns></returns>
        public bool AddOrder(bool buy, int sID, int pID, int cID)
        {
            if (buy)
            {
                Order order = new Order();
                order.CustomerID = cID;
                order.ProductID = pID;
                order.StoreID = sID;
               

                _orderRepoInstance.InsertOrder(order);

                return true;
            }
            return false;
        }
        /// <summary>
        /// returns specific orders from a store
        /// connects to the store repository because it does not have
        /// direct access to storage
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>
        public List<Order> ReadStoreOrders(int storeKey)
        {
            return _orderRepoInstance.ReadSpecificStoreOrder(storeKey);

        }

        /// <summary>
        /// returns orders from a customer
        /// connects to order repository because it doesn't have direct access to storage
        /// </summary>
        /// <param name="customerkey"></param>
        /// <returns></returns>
        public List<Order>ReadCustomerOrders(int customerkey)
        {
            return _orderRepoInstance.ReadSpecificOrder(customerkey);
        }
    }
}

   
