using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Mappers
{
   public class StoreMapper
    {
        public ViewStore StoreToViewStore(Store s)
        {
            //get a customer from the repo
            //match all the properties 1 to 1 with a view 
            //make a new vm

            ViewStore vs = new ViewStore();
            //vc.CardNumber = c.CardNumber;
            vs.Address = s.Address;
            vs.StoreId = s.StoreId;

            return vs;

        }
        public List<ViewStore> StoreToViewStore(List<Store> s)
        {
            List<ViewStore> stores = new List<ViewStore>();
            for (int element = 0; element < s.Count; element++)
            {
                stores.Add(new ViewStore());
                stores[element].Address = s[element].Address;
                stores[element].StoreId = s[element].StoreId;
            }

            return stores;
        }

        public Store ViewStoreToStore(ViewStore vs)
        {
            //get a customer from the repo
            //match all the properties 1 to 1 with a view 
            //make a new vm

            Store s = new Store();
            //vc.CardNumber = c.CardNumber;
            s.Address = vs.Address;
            s.StoreId = vs.StoreId;

            return s;

        }
    }
}
