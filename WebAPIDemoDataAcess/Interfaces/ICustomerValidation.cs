using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer.Interfaces
{
    public interface ICustomerValidation
    {

        public bool validateName(string name);

        public bool validateEmail(string email);

        public bool validatePassword(string password);

        public bool validatePaymentMethod(long? cardNumber);
    }
}
