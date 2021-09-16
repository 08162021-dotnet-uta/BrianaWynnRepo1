using Microsoft.AspNetCore.Mvc;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoDataAcess.EntityModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {


        //get a reg instance with code dependency
        private readonly ViewCustomer _vc = new ViewCustomer();
       // private readonly CoreDbContext _dbContext = new CoreDbContext();//for testing purposes only. This does not stay here in the final code
        private readonly CustomerRepository _cr = new CustomerRepository();
        private readonly CustomerMapper _cm = new CustomerMapper();

        // GET: api/<CustomersController>

        [HttpGet]
        public ViewCustomer Login(ViewCustomer c)
        {
            if (!ModelState.IsValid) return c;

            //send the username and password to business layer to check for that guy
            //if found returns the userId
            //if not found returns -1

            //int userId = _cr.LoginCustomer(username, password);
            return c;

        }

        [HttpPost]
        public ViewCustomer Register(ViewCustomer c)
        {
            //ViewCustomer a = new ViewCustomer { FirstName = "ben", LastName = "franklin", Email = "thwothein@gmail.com", PWord = "ethiel" };
            //use mapper and convert to Customer
            //call repository to insert the customer
            Customer cust = _cm.ViewCustomerToCustomer(c);
            //I added the data, here is the customer I just added
            //convert it back to view customer
            ViewCustomer d = _cm.CustomerToViewCustomer(_cr.Register(cust));
            //return me to the user
            //d
            return c;
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
    }//eoc
}//eon
