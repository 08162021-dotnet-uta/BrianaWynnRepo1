using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Interfaces
{
   public interface IStoreRepository
    {
        public List<Store> AllStore();


        public List<ViewStoreOrder> StoreOrder();


        public List<ViewStoreOrder> StoreOrder(int num);


        public List<ViewStoreOrder> StoreOrder(Customer c);
       
    }
}
