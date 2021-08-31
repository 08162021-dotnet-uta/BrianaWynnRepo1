using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using System.Linq;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Client.Singletons;
using Serilog;


namespace Project0.StoreApplication.Client

{
  class Program
  {

        /// <summary>
        /// returns a store singleton 
        /// </summary>
        private static readonly StoreSingleton _singletonS = StoreSingleton.GetStoreSingletonInstance();
        /// <summary>
        /// returns a customer singleton
        /// </summary>
        private static readonly CustomerSingleton _singletonC = CustomerSingleton.GetCustomerSingletonInstance();
        /// <summary>
        /// returns a product singleton
        /// </summary>
        private static readonly ProductSingleton _singletonP = ProductSingleton.GetProductSingletonInstance();
        /// <summary>
        /// returns an order singleton
        /// </summary>
        private static readonly OrderSingleton _singletonO = OrderSingleton.GetOrderSingletonInstance();
        private static string _logPath = @"C:\Users\bnwyn\source\repos\08162021-dotnet-uta\BrianaWynnRepo1\projects\project_0\data\logs.txt";

        static void Main(string[] args)
        {

            DetermineRunPath();
            //Log.Logger = new LoggerConfiguration().WriteTo.File(_logPath).CreateLogger();


        }
        
        /// <summary>
        /// This is the order of commands that execute when a customer wants to buy a product
        /// </summary>
        public static void RunCustomerBuy()
        {
            _singletonC.PrintCustomerNames();
            var selectedCustomer = _singletonC.CaptureCustomerInput();
            _singletonC.PrintSelectedCustomer(selectedCustomer);
            var customerID = _singletonC.SelectedCustomerID(selectedCustomer);

            _singletonS.PrintStoreNames();
            var selectedStore = _singletonS.CaptureStoreInput();
            _singletonS.PrintSelectedStore(selectedStore);
            var storeID = _singletonS.SelectedStoreID(selectedStore);

            _singletonP.PrintProductNames();
            var selectedProduct = _singletonP.CaptureProductInput();
            _singletonP.PrintSelectedProduct(selectedProduct);
            var productID = _singletonP.SelectedProductID(selectedProduct);


            bool buy = _singletonP.ConfirmPurchase();

            _singletonO.AddOrder(buy,storeID ,productID ,customerID);
        }

        /// <summary>
        /// This is the methods that execute when the customer would like to review an order
        /// </summary>
        public static void RunCustomerReview()
        {
            _singletonC.PrintCustomerNames();
            var selectedCustomer = _singletonC.CaptureCustomerInput();
            _singletonC.PrintSelectedCustomer(selectedCustomer);
            var customerID = _singletonC.SelectedCustomerID(selectedCustomer);

           List<Order> customerOrders =  _singletonO.ReadCustomerOrders(customerID);

           //Console.WriteLine("you purchased: {0} from {1}", _singletonP.GetProductName(customerOrders[0].ProductID - 1), _singletonS.GetStoreName(customerOrders[0].StoreID - 1));


        }
        /// <summary>
        /// these are the methods that execute when the store wants to review order history
        /// </summary>
        public static void RunStoreReview()
        {
            _singletonS.PrintStoreNames();
            var selectedStore = _singletonS.CaptureStoreInput();
            _singletonS.PrintSelectedStore(selectedStore);
            var storeID = _singletonS.SelectedStoreID(selectedStore);

            List<Order> storeOrders = _singletonO.ReadStoreOrders(storeID);

            //Console.WriteLine("{0} purchased: {1}", _singletonC.GetCustomerName(storeOrders[0].CustomerID - 1), _singletonS.GetProductName(customerOrders[0].ProductID - 1));
        }

        /// <summary>
        /// This is the method that holds the logic for determining which path to execute
        /// The paths possible are RunCustomerBuy, RuCustomerReview, RunStoreReview
        /// </summary>
        public static void DetermineRunPath()
        {
            Console.WriteLine("Would you like to run as a manager \n [1] -No \n Enter 1 if you are not a manager");
            int selected;
            bool result = int.TryParse(Console.ReadLine(), out selected);

            if(selected == 1234)
            {
                RunStoreReview();
            }
            else 
            {
                
                int customerSelected;
                bool customerResult = false;
                do
                {
                    Console.WriteLine("Welcome to Sword & Spell: What would you like to do today? \n [1] Make a purchase \n [2] Review Past Orders \n Please Enter the corresponding number: ");
                    customerResult = int.TryParse(Console.ReadLine(), out customerSelected);
                } while (!customerResult);

                if(customerSelected == 1)
                {
                    RunCustomerBuy();
                }
                else if (customerSelected == 2){
                    RunCustomerReview();
                }
            }
        }        
    }
}





