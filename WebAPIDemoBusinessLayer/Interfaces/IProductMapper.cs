using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Interfaces
{
   public interface IProductMapper
    {
        public static ViewModelProduct ProductToViewModelProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public static List<ViewModelProduct> ProductToViewModelProduct(List<Product> p)
        {
            throw new NotImplementedException();
        }
    }
}
