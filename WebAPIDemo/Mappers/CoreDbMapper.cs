using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemo.Mappers
{
    public class CoreDbMapper: Profile
    {
        public CoreDbMapper()
        {
            CreateMap<ViewModels.ViewCustomer, Customer>();
            CreateMap<Customer, ViewModels.ViewCustomer>();
        }
    }
}
