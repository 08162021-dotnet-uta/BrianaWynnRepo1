using System;
using Xunit;
using WebAPIDemoBusinessLayer.Validation;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.Interfaces;

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
    }
}
