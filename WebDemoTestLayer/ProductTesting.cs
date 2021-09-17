using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;
using Xunit;

namespace WebDemoTestLayer
{
    public class ProductTesting
    {

      

        [Fact]
        public void MapperToViewModelProduct()
        {
            //Arrange
            Product c = new Product() { Description = "cool tool", Name = "Hammer", Price = 32.45M };

            //Act
            ViewModelProduct c1 = ProductMapper.ProductToViewModelProduct(c);

            //Assert
            Assert.Equal("cool tool", c1.Description);
            Assert.Equal("Hammer", c1.Name);
            Assert.Equal(32.45M, c1.Price);
        }
    }
}
