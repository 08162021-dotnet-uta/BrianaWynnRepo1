using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.ViewModels;
using WebAPIDemoBusinessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

         // POST api/<CustomerController>
        /// <summary>
        /// Create a new customer in the database (register)
        /// </summary>
        /// <param name="customer"></param>
        [HttpPost]
        public async Task<ActionResult<ViewCustomer>> Post([FromBody] ViewCustomer customer)
        {
            //validate the model
            //validate the values of the model

            //send to the repo to be created
            var returned = await _repo.Create(customer);
            return Ok(returned);
        }

        /// <summary>
        /// Delete a customer in the database
        /// </summary>
        /// <param name="customer"></param>
        [HttpDelete]
        public void Delete([FromBody] ViewCustomer customer)
        {
            //send to repo to be deleted
             _repo.Delete(customer);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ViewCustomer>> Login([FromBody] ViewCustomer customer)
        {
            //send to the repo to be logged in
            var returned = await _repo.Read(customer);
            if(returned == null)
            {
                return Ok("Invalid Credentials");
            }
            else
            {
                return Ok(returned);
            }
            
        }

        [HttpPut]
        public void Put([FromBody] ViewCustomer customer)
        {
            //send to the repo to be updated
            _repo.Update(customer);
        }
    
    }
}
