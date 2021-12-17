using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public class OrderMapper : IMapper<ViewOrder, Order>
    {
        public ViewOrder ModelToViewModel(Order entity)
        {
            ViewOrder order = new ViewOrder();
            order.OrderId = entity.OrderId;
            order.OrderDate = entity.OrderDate;
            order.StoreId = entity.StoreId;
            order.CustomerId = entity.CustomerId;

            return order;
        }

        public Order ViewModelToModel(ViewOrder entity)
        {
            Order order = new Order();
            order.OrderId = entity.OrderId;
            order.OrderDate = entity.OrderDate;
            order.StoreId = entity.StoreId;
            order.CustomerId = entity.CustomerId;

            return order;
        }
    }
}
