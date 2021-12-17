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
        CoreDbContext _context;

        public ProductRepository(CoreDbContext context) 
        {
            
            _context = context;
        }

        //public Product RandomProduct() {

        //    Random r = new Random();

        //    Product product = _context.Products.Where(p => p.ProductId == r.Next(10, 22)).FirstOrDefault(); 
        //    return product;
        //}

        //public List<Product> RandomProduct(int num)
        //{

        //    List<int> productnums = new List<int>() { 21, 11, 10, 15 };

        //    List<Product> p = new List<Product>();
        //    for (int i = 0; i < num; i++)
        //    {
        //        p.Add(new Product());
        //        p[i] = _context.Products.FromSqlInterpolated($"Select * from Products where ProductId = {productnums[i]}").FirstOrDefault();
        //    }
        //    return p;
        //}

        public List<Product> GetAllProduct()
        {
            List<Product> lstProduct = null;
            try
            {
                lstProduct = _context.Products.OrderBy(p => p.Name).ToList();
            }
            catch(Exception ex)
            {
                lstProduct = null;
            }
            return lstProduct;

        }

        //public List<Product> GetAllProduct(int storeId)
        //{
        //    List<Product> lstProduct = null;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return lstProduct;
        //}

        public Product GetProduct(Product productObj)
        {
            Product product = null;
            try
            {
                product = _context.Products.Find(productObj.ProductId);
            }
            catch (Exception ex)
            {
                product = null;
            }
            return product;
        }

        public bool AddProduct(Product product)
        {
            bool status;
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteProduct(Product product)
        {
            bool status;
            try
            {
                Product deleteProduct = _context.Products.Find(product.ProductId);
                if(deleteProduct != null)
                {
                    _context.Products.Remove(deleteProduct);
                    _context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateProduct(Product product)
        {
            bool status;
            try
            {
                Product prod = _context.Products.Find(product.ProductId);
                if(prod != null)
                {
                    prod.Price = product.Price;
                    prod.Name = product.Name;
                    prod.Description = product.Description;
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }


    }
}
