using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoDataAcess.Repositories
{
    public class StoreRepository
    {
        private readonly CoreDbContext _context;

        public StoreRepository(CoreDbContext dbContext) {

            _context = dbContext;
        }

        public StoreRepository() { }

        CoreDbContext _dbContext = new CoreDbContext();

      
        
        public List<Store> GetAllStores()
        {
            List<Store> lstStore = null;
            try
            {
                lstStore = _context.Stores.ToList();
            }
            catch (Exception)
            {
                lstStore = null;
            }

            return lstStore;
        }

        public Store GetStore(Store storeObj)
        {
            Store store = null;
            try
            {
                store = _context.Stores.Find(storeObj.StoreId);

            }
            catch (Exception)
            {
                store = null;
            }

            return store;
        }

        public bool AddStore(Store store)
        {
            bool status;
            try
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public bool DeleteStore(Store store)
        {
            bool status;
            try
            {
                Store deleteStore = _context.Stores.Find(store.StoreId);
                if(deleteStore != null)
                {
                    _context.Stores.Remove(deleteStore);
                    _context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public bool UpdateStore(Store store)
        {
            bool status;
            try
            {
                Store dbStore = _context.Stores.Find(store.StoreId);
                if(dbStore != null)
                {
                    dbStore.Address = store.Address;
                    _context.SaveChanges();
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        //public List<ViewStoreOrder> StoreOrder()
        //{
        //    // convert to viewCustomers. This would be for formatting responsiblities
        //    //for demo, just return the entire customer

        //    List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder").ToList();

        //    //go add the entity model
        //    //entity model added
        //    //switch to getting an Inventory
        //    Console.WriteLine(entityStoreOrder[0].OrderId);


        //    return entityStoreOrder; 
        //}

        //public List<ViewStoreOrder> StoreOrder(int num)
        //{
        //    // convert to viewCustomers. This would be for formatting responsiblities
        //    //for demo, just return the entire customer

        //    List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder where storeId = {num}").ToList();

        //    //go add the entity model
        //    //entity model added
        //    //switch to getting an Inventory
        //    if (entityStoreOrder.Count < 1)
        //    {
        //        Console.WriteLine("no orders placed at store");
        //        entityStoreOrder.Add(new ViewStoreOrder());
        //        entityStoreOrder[0].FirstName = "No Orders Placed at Store Location";
        //        return entityStoreOrder;
        //    }
        //    else
        //    {
        //        return entityStoreOrder;
        //    }

          
        //}

        //public List<ViewStoreOrder> CustomerOrder(int c)
        //{
        //    // convert to viewCustomers. This would be for formatting responsiblities
        //    //for demo, just return the entire customer

        //    List<ViewStoreOrder> entityStoreOrder = _dbContext.ViewStoreOrder.FromSqlInterpolated($"SELECT * from ViewStoreOrder where customerId = {c}").ToList();

        //    //go add the entity model
        //    //entity model added
        //    //switch to getting an Inventory
        //    //Console.WriteLine(entityStoreOrder[0].OrderId);


        //    return entityStoreOrder;
        //}

        //public List<ViewStoreOrder> StoreOrder(Customer c)
        //{
        //    throw new NotImplementedException();
        //}
    }//eoc
}//eon
