using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Interfaces
{
    public interface IStoreMapper
    {
        public ViewStore StoreToViewStore(Store s);
        public List<ViewStore> StoreToViewStore(List<Store> s);


        public Store ViewStoreToStore(ViewStore vs);
     
    }
}
