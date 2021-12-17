using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{
    public class ProductRepository
    {
        CoreDbContext _dbContext = new CoreDbContext();

        public ProductRepository() { }

        public Product RandomProduct() {

            Random r = new Random();

            Product p = _dbContext.Products.FromSqlInterpolated($"Select * from Products where ProductId = {r.Next(10, 22)}" ).FirstOrDefault();
            return p;
        }

        public List<Product> RandomProduct(int num)
        {

            List<int> productnums = new List<int>() { 21, 11, 10, 15 };

            List<Product> p = new List<Product>();
            for (int i = 0; i < num; i++)
            {
                p.Add(new Product());
                p[i] = _dbContext.Products.FromSqlInterpolated($"Select * from Products where ProductId = {productnums[i]}").FirstOrDefault();
            }
            return p;
        }

        public List<Inventory> AllProduct()
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<Inventory> entityProducts = _dbContext.Inventory.FromSqlInterpolated($"SELECT * from Inventory").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            Console.WriteLine(entityProducts[0].Description);


            return entityProducts; //count = 21 when you check the infomration is there
        }

        public List<Inventory> AllProduct(int num)
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<Inventory> entityProducts = _dbContext.Inventory.FromSqlInterpolated($"SELECT * from Inventory where storeId = {num}").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            Console.WriteLine(entityProducts[0].Description);


            return entityProducts; //count = 21 when you check the infomration is there
        }
    }
}
