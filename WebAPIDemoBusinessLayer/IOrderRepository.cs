using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public interface IOrderRepository: IRepository<ViewOrder, Guid>
    {
        Task<List<ViewOrder>> Read(Guid orderId);
    }
}
