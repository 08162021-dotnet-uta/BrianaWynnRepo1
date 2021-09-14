using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIDemoDataAcess.EntityModels;
using WebAPIDemoBusinessLayer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]/[action]/{id}")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        

        //get a reg instance with code dependency
        private readonly ViewCustomer _vc = new ViewCustomer();
        private readonly CoreDbContext _dbContext = new CoreDbContext();//for testing purposes only. This does not stay here in the final code


        // GET: api/<CustomersController>

        [HttpGet]
        public List<ViewCustomer> Customers()
        {
            return _vc.formatCustomers();

        }

        [HttpGet]
        //public List<Order> CustomerOrders()
        //{
        //   //get all the orders they placed
        //    List<Order> allOrders = _dbContext.Orders.FromSqlInterpolated($"SELECT * FROM ORDERS WHERE customerId = 1").ToList();

        //    //match to the order product table to get the product ids
        //    for  (int i = 0; i<allOrders.Count; i++) {
        //        List<ProductOrder> allProductOrder = _dbContext.ProductOrders.FromSqlInterpolated($"SELECT * FROM ProductOrders where orderId = {0}",)
        //     }
        //    Order order1 = allOrders[1];

        //    return order1.ProductOrders;

        //}

        

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
