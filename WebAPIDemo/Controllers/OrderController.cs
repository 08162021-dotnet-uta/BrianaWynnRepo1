using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IRepository<ViewOrder> _repo;

        public OrderController(IRepository<ViewOrder> repo)
        {
            _repo = repo;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<ViewOrder>> Get()
        {
            //return all orders from the db for a specific store
            //return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //get a single order for a specific customer
            //useful for getting the details of a single order that the customer can click on
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //recieve an order and put it in the database
            //check the products in the order to decrement the quantity in the database

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //update an order. Useful if a customer makes a change after the order has been added to the db
            //used by administration only

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //customer can use this option to cancel an order after it has been placed
        }
    }
}
