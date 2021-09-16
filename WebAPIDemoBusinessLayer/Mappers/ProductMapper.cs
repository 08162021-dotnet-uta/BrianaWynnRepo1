using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Mappers
{
    public class ProductMapper
    {
        
        public static ViewModelProduct ProductToViewModelProduct(Product p)
        {
            ViewModelProduct vp = new ViewModelProduct() { 
                Description = p.Description, 
                Name = p.Name,
                Price = p.Price 
            };

            return vp;
        }

        public static List<ViewModelProduct> ProductToViewModelProduct(List<Product> p)
        {
            List<ViewModelProduct> products = new List<ViewModelProduct>();
            for (int element = 0; element < p.Count; element++)
            {
                products.Add(new ViewModelProduct());
                products[element].Name = p[element].Name;
                products[element].Description = p[element].Description;
                products[element].Price = p[element].Price;
            }

            return products;
        }
    }//Eoc
}//EoN
