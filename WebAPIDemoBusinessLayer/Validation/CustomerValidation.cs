using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;

namespace WebAPIDemoBusinessLayer.Validation
{
    public class CustomerValidation : ICustomerValidation
    {
        public CustomerValidation()
        {

        }
        bool ICustomerValidation.validateEmail(string email)
        {
           if(email.Length > 100)
            {
                return false;
            }
            return true;
        }

        bool ICustomerValidation.validateName(string name)
        {
            if (name == null)
            {
                return false;
            }
            else if (name.Length > 50)
            {
                return false;
            }
            return true;
        }

        bool ICustomerValidation.validatePassword(string password)
        {
            //check if the password contains an upper case
            bool result = true;
            do {
                for (int i = 0; i < password.Length; i++)
                {
                   result = Char.IsUpper(password, i);

                }
            }while (!result) ;
            return true;

        }

        bool ICustomerValidation.validatePaymentMethod(long? cardNumber)
        {
            throw new NotImplementedException();
        }
    }//EOc
}//EoN
