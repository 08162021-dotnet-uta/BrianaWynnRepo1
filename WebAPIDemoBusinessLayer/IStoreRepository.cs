using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public interface IStoreRepository: IRepository<ViewStore, int>
    {
        Task<List<ViewProduct>> Read(int storeId);
    }
}
