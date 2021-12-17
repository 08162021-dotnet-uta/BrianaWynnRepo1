using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public class ProductRepository : IRepository<ViewProduct, int>
    {
        public Task<ViewProduct> Create(ViewProduct entity)
        {
            //add a new product to the database
            //admin feature
            throw new NotImplementedException();
        }

        public void Delete(ViewProduct entity)
        {
            //delete a product from the database
            //admin feature
            throw new NotImplementedException();
        }

        public Task<ViewProduct> Read(ViewProduct entity)
        {
            //return a specific product
            throw new NotImplementedException();
        }

        public Task<List<ViewProduct>> Read()
        {
            //return all product from all store
            //admin feature
            throw new NotImplementedException();
        }

        public void Update(ViewProduct entity)
        {
            //update a product
            //admin feature
            throw new NotImplementedException();
        }
    }
}
