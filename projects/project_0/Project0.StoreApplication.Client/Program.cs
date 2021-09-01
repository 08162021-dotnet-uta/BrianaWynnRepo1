using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using System.Linq;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Client.Singletons;
using Serilog;
using Project0.StoreApplication.Storage.Adapters;

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

           
            Log.Logger = new LoggerConfiguration().WriteTo.File(_logPath).CreateLogger();
            DetermineRunPath();
            Log.CloseAndFlush();


        }

        /// <summary>
        /// This is the order of commands that execute when a customer wants to buy a product
        /// </summary>
        public static void RunCustomerBuy()
        {
            _singletonC.PrintCustomerNames();
            var selectedCustomer = _singletonC.CaptureCustomerInput();
            Log.Information($"You requested the user's customer input: {selectedCustomer}");
           
            _singletonC.PrintSelectedCustomer(selectedCustomer);
            var customerID = _singletonC.SelectedCustomerID(selectedCustomer);
            Log.Information($"You retrieved the customerID from file storage: {customerID}");

            _singletonS.PrintStoreNames();
            var selectedStore = _singletonS.CaptureStoreInput();
            _singletonS.PrintSelectedStore(selectedStore);
            var storeID = _singletonS.SelectedStoreID(selectedStore);
            Log.Information($"You requested the user's input {selectedStore} and storeID {storeID}");

            _singletonP.PrintProductNames();
            var selectedProduct = _singletonP.CaptureProductInput();
            _singletonP.PrintSelectedProduct(selectedProduct);
            var productID = _singletonP.SelectedProductID(selectedProduct);
            Log.Information($"You requested the user's product input {selectedProduct} and retrieved productID {productID}");

            bool buy = _singletonP.ConfirmPurchase();
            Log.Information($"Does the Customer Want to buy the product: {buy} ");

            _singletonO.AddOrder(buy, storeID, productID, customerID);
        }

        ///// <summary>
        ///// This is the methods that execute when the customer would like to review an order
        ///// </summary>
        public static void RunCustomerReview()
        {
            _singletonC.PrintCustomerNames();
            var selectedCustomer = _singletonC.CaptureCustomerInput();
            Log.Information($"You requested the user's customer input: {selectedCustomer}");
            _singletonC.PrintSelectedCustomer(selectedCustomer);
            var customerID = _singletonC.SelectedCustomerID(selectedCustomer);
            Log.Information($"You retrieved the customerID from file storage: {customerID}");

            List<Order> customerOrders = _singletonO.ReadCustomerOrders(customerID);

            for (int i = 0 ; i < customerOrders.Count; i++)
            {
                int purchasedIndex = customerOrders[i].ProductID - 1;
                string productName = _singletonP.GetProductName(purchasedIndex);

                int storeIndex = customerOrders[i].StoreID - 1;
                string storeName = _singletonS.GetStoreName(storeIndex);

                double price = _singletonP.GetPrice(purchasedIndex);
                Console.WriteLine($"\n Order[{i +1}]: You purchased {productName} for ${price} from {storeName}");
            }
            Log.Information($"Check the Customer Orders List: {customerOrders}");
            

        }
        ///// <summary>
        ///// these are the methods that execute when the store wants to review order history
        ///// </summary>
        public static void RunStoreReview()
        {
            _singletonS.PrintStoreNames();
            var selectedStore = _singletonS.CaptureStoreInput();
            _singletonS.PrintSelectedStore(selectedStore);
            var storeID = _singletonS.SelectedStoreID(selectedStore);

            List<Order> storeOrders = _singletonO.ReadStoreOrders(storeID);

            
            for (int i = 0; i < storeOrders.Count; i++)
            {
                int purchasedIndex = storeOrders[i].ProductID - 1;
                string productName = _singletonP.GetProductName(purchasedIndex);

                int customerIndex = storeOrders[i].CustomerID - 1;
                string customerName = _singletonC.ReadSpecificCustomerName(customerIndex); 

                double price = _singletonP.GetPrice(purchasedIndex);
                Console.WriteLine($"\n Order[{i + 1}]: {customerName} purchased {productName} for: ${price} ");
            }
            Log.Information($"Check the Store Orders List: {storeOrders}");


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
            Log.Debug($"Does the user want to run as manager: {result}");

            if (selected == 1234)
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
                    Log.Debug($"Did the customer enter a number? {customerResult}");
                    Log.Information($"User Input for selecting run path -- should be 1 or 2 {customerSelected}");
                    Log.Warning($"I'm still in the do while loop");
                } while (!customerResult);

                if (customerSelected == 1)
                {
                    RunCustomerBuy();
                    Log.Information($"Customer decided to run as a buyer");
                }
                else if (customerSelected == 2)
                {
                    RunCustomerReview();
                    Log.Information($"Customer decided to review previous orders");
                }
            }
        }
    }
}





