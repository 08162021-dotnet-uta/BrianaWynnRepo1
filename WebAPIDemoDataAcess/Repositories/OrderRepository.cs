using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{
    public class OrderRepository
    {
        CoreDbContext _dbContext = new CoreDbContext();
        public void Place(Order o)
        {
            //I added the person to the database
            //_dbContext.Customers.FromSqlInterpolated($"insert into Customers (FirstName, LastName, email, pWord) values ({c.FirstName},{c.LastName},{c.Email},{c.PWord}");
            _dbContext.Orders.Add(o);
            _dbContext.SaveChanges();

           
        }
    }
}
