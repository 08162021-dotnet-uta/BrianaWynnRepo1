using System;
using Xunit;
using WebAPIDemoBusinessLayer.Validation;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoDataAcess.EntityModels;

namespace WebDemoTestLayer
{
    public class CustomerTesting
    {
        public CustomerTesting() { }
       
        [Theory]
        [InlineData("Sumthim1@", 0)]
        [InlineData("biggySmall3!",5)]
        [InlineData("pass#\\worD", 9)]
        public void UpperCaseInPassWordFromValidatePassword(string str, int index)
        {
            //Arrange
            ICustomerValidation valley = new CustomerValidation();

            bool expected = Char.IsUpper(str, index);

            //Act
            bool result = valley.validatePassword(str);


            //Assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void MapperToCustomer()
        {
            //Arrange
            ViewCustomer c = new ViewCustomer() { FirstName = "Ben", LastName = "Franklin", Email = "bennyfrank@gmail.com", PWord = "something" };

            //Act
            ICustomerMapper mapper = new CustomerMapper();

            Customer c1 = mapper.ViewCustomerToCustomer(c);
            //Assert
            Assert.Equal("Ben", c1.FirstName);
            Assert.Equal("Franklin", c1.LastName);
            Assert.Equal("bennyfrank@gmail.com", c1.Email);
            Assert.Equal("something", c1.PWord);
        }

        [Fact]
        public void MapperToViewCustomer()
        {
            //Arrange
            Customer c = new Customer() { FirstName = "Ben", LastName = "Franklin", Email = "bennyfrank@gmail.com", PWord = "something" };

            //Act
            ICustomerMapper mapper = new CustomerMapper();
            ViewCustomer c1 = mapper.CustomerToViewCustomer(c);
            //Assert
            Assert.Equal("Ben", c1.FirstName);
            Assert.Equal("Franklin", c1.LastName);
            Assert.Equal("bennyfrank@gmail.com", c1.Email);
            Assert.Equal("something", c1.PWord);
        }

        //mock the database so you can test the repository methods

    }//eoc
}//eon
