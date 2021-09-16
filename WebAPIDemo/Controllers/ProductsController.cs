using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductRepository _pr = new ProductRepository();

       // GET: api/<ProductsController>
       [HttpGet]
        public ViewModelProduct Random()
        {
            //model mapper changes from entity to vp
            //repository calls for a random product
            return ProductMapper.ProductToViewModelProduct((_pr.RandomProduct()));
        }
        [HttpGet()]
        public List<ViewModelProduct> BottomCards()
        {
            //model mapper changes from entity to vp
            //repository calls for a random product
            return ProductMapper.ProductToViewModelProduct((_pr.RandomProduct(4)));
        }

        // GET api/<ProductsController>/5
        [HttpGet]
        public List<Inventory> Inventory()
        {
            //get the products from all stores
            //call to the product repo to retrive the products for all stores
            List<Inventory> inventory = new List<Inventory>();
           
            foreach(var i in _pr.AllProduct())
            {
                inventory.Add(i);
            }
               
            return inventory;
        }
        [HttpGet("{id}")]
        public List<Inventory> Inventory(int id)
        {
            //get the products from all stores
            //call to the product repo to retrive the products for all stores
            List<Inventory> inventory = new List<Inventory>();

            foreach (var i in _pr.AllProduct(id))
            {
                inventory.Add(i);
            }

            return inventory;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
