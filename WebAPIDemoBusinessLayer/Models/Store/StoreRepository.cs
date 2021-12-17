using Microsoft.EntityFrameworkCore;
using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer
{
    public class StoreRepository : IStoreRepository
    {
        private readonly CoreDbContext _context;
        private readonly IMapper<ViewStore, Store> _mapper;
        private readonly IMapper<ViewProduct, Product> _productMapper;
        public StoreRepository(CoreDbContext context, IMapper<ViewStore,Store> mapper, IMapper<ViewProduct, Product> productMapper)
        {
            _context = context;
            _mapper = mapper;
            _productMapper = productMapper;
        }
        public Task<ViewStore> Create(ViewStore entity)
        {
            throw new NotImplementedException();
            //admin functionality implement later
        }

        public void Delete(ViewStore entity)
        {
            throw new NotImplementedException();
            //admin functionality implement later
        }

        public Task<ViewStore> Read(ViewStore entity)
        {
            throw new NotImplementedException();
            //not sure how this will be used
        }

        public async Task<List<ViewStore>> Read()
        {
           List<Store> returned = await _context.Stores.ToListAsync();
            return returned.ConvertAll(_mapper.ModelToViewModel);
        }

        public async Task<List<ViewProduct>> Read(int storeId)
        {
            //get the store inventory
            List<ProductStore> returned = await _context.ProductStores
                                        .Where(s => s.StoreId == storeId)
                                        .Include("Product")
                                        .ToListAsync();

            List<Product> inventory = Inventory(returned);
            return inventory.ConvertAll(_productMapper.ModelToViewModel);
            
        }

        private List<Product> Inventory(List<ProductStore> inventory)
        {
            List<Product> products = new List<Product>();
            foreach (var product in inventory)
            {
                products.Add(product.Product);
            }

            return products;

        }
        
        public void Update(ViewStore entity)
        {
            throw new NotImplementedException();
            //admin functionality implement later
        }
    }
}
