using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreRepository _sr = new StoreRepository();
        IStoreMapper _sm = new StoreMapper();
        ICustomerMapper _cm = new CustomerMapper();
        // GET: api/<StoreController>
        [HttpGet]
        public List<ViewStore> Store()
        {
            //retrieve the stores
            //map them to view stores and return them.

            List<Store> stores = new List<Store>();

            foreach (var i in _sr.AllStore())
            {
                stores.Add(i);
            }

            return _sm.StoreToViewStore(stores);

           
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public List<ViewStoreOrder> Order(int id)
        {
            //get the products from all stores
            //call to the product repo to retrive the products for all stores
            List<ViewStoreOrder> orders = new List<ViewStoreOrder>();

            foreach (var i in _sr.StoreOrder(id))
            {
                orders.Add(i);
            }

            return orders;
            
        }

        [HttpGet("{id}")]
        public List<ViewStoreOrder> Customer(int id)
        {
            //get the products from all stores
            //call to the product repo to retrive the products for all stores
            List<ViewStoreOrder> orders = new List<ViewStoreOrder>();
            //convert from view customer to customer
           // Customer c = _cm.ViewCustomerToCustomer(cust);
            foreach (var i in _sr.CustomerOrder(id))
            {
                orders.Add(i);
            }

            return orders;

        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
