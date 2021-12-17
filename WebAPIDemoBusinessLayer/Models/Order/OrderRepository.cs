using Microsoft.EntityFrameworkCore;
using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer
{
   public class OrderRepository : IOrderRepository
    {
        private readonly CoreDbContext _context;
        private readonly IMapper<ViewOrder, Order> _mapper;
        public OrderRepository(CoreDbContext context, IMapper<ViewOrder,Order> mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ViewOrder> Create(ViewOrder entity)
        {
            //customers can create a new order
            throw new NotImplementedException();
        }

        public void Delete(ViewOrder entity)
        {
            //customers can cancel there order during a certain time frame
            throw new NotImplementedException();
        }

        public Task<ViewOrder> Read(ViewOrder entity)
        {
            //customers can review a specific Order
            throw new NotImplementedException();
        }

        public Task<List<ViewOrder>> Read()
        {
            //return all orders in the system 
            //admin feature 
            throw new NotImplementedException();
        }

        public async Task<List<ViewOrder>> Read(Guid orderId)
        {
            //Details of specific order
            List<ProductOrder> productOrders = await _context.ProductOrders
                                                .Where(o => o.OrderId == orderId)
                                                .Include("Product")
                                                .ToListAsync();

            List<Order> order = OrderWithProducts(productOrders);
            return order.ConvertAll(_mapper.ModelToViewModel);
        }

        private List<Order> OrderWithProducts(List<ProductOrder> productOrders)
        {
            List<Order> orders = new List<Order>();
            foreach(var product in productOrders)
            {
                orders.Add(product.Order);
            }
            return orders;
        }

        public void Update(ViewOrder entity)
        {
            //customers can update an order
            //implement later
            throw new NotImplementedException();
        }
    }
}
