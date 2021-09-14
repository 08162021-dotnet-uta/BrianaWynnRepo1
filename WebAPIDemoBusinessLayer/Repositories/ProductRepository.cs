using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{
    class ProductRepository
    {
        CoreDbContext _dbContext = new CoreDbContext();

        //public List<Product> GetProducts()
        //{
        //    // convert to viewCustomers. This would be for formatting responsiblities
        //    //for demo, just return the entire customer

        //    List<Product> entityProducts = _dbContext.Products.FromSqlInterpolated($"SELECT * Products").ToList();


        //    return entityProducts;
        //}
    }
}
