using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public class ProductMapper : IMapper<ViewProduct, Product>
    {
        public ViewProduct ModelToViewModel(Product entity)
        {
            ViewProduct product = new ViewProduct();
            product.ProductId = entity.ProductId;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Name = entity.Name;

            return product;
        }

        public Product ViewModelToModel(ViewProduct entity)
        {
            Product product = new Product();
            product.ProductId = entity.ProductId;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Name = entity.Name;

            return product;
        }
    }
}
