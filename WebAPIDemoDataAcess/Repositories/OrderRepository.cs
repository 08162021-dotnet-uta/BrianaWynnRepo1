using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{    //Todo List:
     //1. Add Exception Handling
     //2. switch to async methods
     //3. add xml comments
    public class OrderRepository
    {
        private readonly CoreDbContext _context;

        public OrderRepository(CoreDbContext context)
        {
            _context = context;
        }

        public bool AddOrder(Order order)
        {
            bool status;
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                status = true;

            }
            catch(Exception ex)
            {
                status = false;
            }
            return status;
        }

        public Order GetOrder(Order order)
        {
            Order dbOrder = null;
            try
            {
                dbOrder = _context.Orders.Find(order.OrderId);
            }
            catch (Exception ex)
            {
                dbOrder = null;
            }
            return dbOrder;
        }

        public List<Order> GetOrders()
        {
            List<Order> dbOrder = null;
            try
            {
                dbOrder = _context.Orders.ToList();

            }
            catch (Exception ex)
            {
                dbOrder = null;
            }
            return dbOrder;

        }

        public bool DeleteOrder(Order order)
        {
            bool status;
            try
            {
                Order deleteOrder = _context.Orders.Find(order.OrderId);
                if(deleteOrder != null)
                {
                    _context.Orders.Remove(deleteOrder);
                    _context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                status = false;

            }
            return status;

        }


        //public bool UpdateOrder(Order order)
        //{
        //    bool status;
        //    try
        //    {
        //        Order dbOrder = _context.Orders.Find(order.OrderId);
        //        if(dbOrder != null)
        //        {
        //            dbOrder.
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return status;
        //}
      
    }
}
