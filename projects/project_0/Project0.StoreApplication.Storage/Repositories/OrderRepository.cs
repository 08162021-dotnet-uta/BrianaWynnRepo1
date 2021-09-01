using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.StoreApplication.Storage.Repositories
{
    public class OrderRepository
    {
        

        private static readonly DBAdapter _da = new DBAdapter();
        private static readonly FileAdapter _fa = FileAdapter.GetFileAdapterInstance();
        private static OrderRepository _orderRepoInstance = null;

        private static string _filePath = @"C:\Users\bnwyn\source\repos\08162021-dotnet-uta\BrianaWynnRepo1\projects\project_0\data\order.xml";
        List<Order> orders = new List<Order>();

        /// <summary>
        /// private constructor for singleton instantiation
        /// </summary>
        private OrderRepository()
        {
            if (_fa.ReadFromFile<Order>(_filePath) == null)
            {

                _fa.WriteToFile<Order>(new List<Order>(), _filePath);
            }
        }

       
       /// <summary>
       /// method to return a order repository instance
       /// </summary>
       /// <returns></returns>
        public static OrderRepository GetOrderRepositoryInstance()
        {
            if (_orderRepoInstance == null)
            {
                _orderRepoInstance = new OrderRepository();
            }
            return _orderRepoInstance;
        }
        
        /// <summary>
        /// Insets a customer order into ssms storeapplicationdb
        /// </summary>
        /// <param name="o"></param>
        public void InsertOrder(Order o)
        {           
            orders.Add(o);

            _da.Database.ExecuteSqlRaw("insert into Store.[Order](CustomerID,StoreID,ProductID) values({0},{1},{2})", o.CustomerID, o.StoreID, o.ProductID);
            
         }

        /// <summary>
        /// returns order records for a specific customer from ssms storeapplicationdb
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        public List<Order> ReadSpecificOrder(int customerKey)
        {
            //_da.Orders.FromSqlRaw("select * from Store.[Order] where CustomerID = {0}", customerKey).ToList();


            //_da.Orders.FromSqlInterpolated($"select * from Store.[Order] Where CustomerID = {customerKey}").FirstOrDefault();

            //var p1 = new SqlParameter("@CustomerID", customerKey);
            //_da.Orders.FromSqlRaw($"Select * from Store.[Order] where CustomerID = @CustomerID", p1).ToList();
            //_da.Orders.FromSqlRaw("select * from Store.[Order] where CustomerID = {0}", customerKey).ToList();
            //_da.Orders.FromSqlRaw("Execute dbo.ReturnOrders {0}", customerKey).ToList();

                        

            return _da.Orders.FromSqlInterpolated($"select * from Store.[Order] where customerID = {customerKey};").ToList();
        }

        /// <summary>
        /// returns records for a single store from ssms storeapplicationdb
        /// </summary>
        /// <param name="storeKey"></param>
        /// <returns></returns>
        public List<Order> ReadSpecificStoreOrder(int storeKey)
        {
            //_da.Orders.FromSqlRaw("select * from Store.[Order] where CustomerID = {0}", customerKey).ToList();


            //_da.Orders.FromSqlInterpolated($"select * from Store.[Order] Where CustomerID = {customerKey}").FirstOrDefault();

            //var p1 = new SqlParameter("@CustomerID", customerKey);
            //_da.Orders.FromSqlRaw($"Select * from Store.[Order] where CustomerID = @CustomerID", p1).ToList();
            //_da.Orders.FromSqlRaw("Execute dbo.ReturnOrders {0}", customerKey).ToList();

            return _da.Orders.FromSqlRaw($"select * from Store.[Order] where StoreID = {storeKey}").ToList();
        }

        /// <summary>
        /// This updates an existing order
        /// Non-functioning
        /// </summary>
        public void UpdateOrder()
        {

        }

        /// <summary>
        /// Deletes an order from storeapplicationdb
        /// Non-functioning
        /// </summary>
        public void DeleteOrder()
        {

        }
      }
}