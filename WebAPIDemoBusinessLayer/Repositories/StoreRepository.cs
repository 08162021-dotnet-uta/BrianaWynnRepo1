using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Repositories
{
    public class StoreRepository
    {
        CoreDbContext _dbContext = new CoreDbContext();

        public StoreRepository() { }

    

      

        public List<Store> AllStore()
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<Store> entityStore = _dbContext.Stores.FromSqlInterpolated($"SELECT * from Stores").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            Console.WriteLine(entityStore[0].Address);


            return entityStore; //count = 21 when you check the infomration is there
        }

        public List<ViewStoreOrder> StoreOrder()
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            Console.WriteLine(entityStoreOrder[0].OrderId);


            return entityStoreOrder; 
        }

        public List<ViewStoreOrder> StoreOrder(int num)
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder where storeId = {num}").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            if (entityStoreOrder.Count < 1)
            {
                Console.WriteLine("no orders placed at store");
                entityStoreOrder.Add(new ViewStoreOrder());
                entityStoreOrder[0].FirstName = "No Orders Placed at Store Location";
                return entityStoreOrder;
            }
            else
            {
                return entityStoreOrder;
            }

          
        }

        public List<ViewStoreOrder> StoreOrder(Customer c)
        {
            // convert to viewCustomers. This would be for formatting responsiblities
            //for demo, just return the entire customer

            List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder where FirstName = {c.FirstName} and LastName = {c.LastName}").ToList();

            //go add the entity model
            //entity model added
            //switch to getting an Inventory
            Console.WriteLine(entityStoreOrder[0].OrderId);


            return entityStoreOrder;
        }


    }
}
