using Models.ViewModels;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public class StoreMapper : IMapper<ViewStore, Store>
    {
        public ViewStore ModelToViewModel(Store entity)
        {
            ViewStore store = new ViewStore();
            store.StoreId = entity.StoreId;
            store.Address = entity.Address;
            return store;
        }

        public Store ViewModelToModel(ViewStore entity)
        {
            Store store = new Store();
            store.StoreId = entity.StoreId;
            store.Address = entity.Address;
            return store;
        }
    }
}
