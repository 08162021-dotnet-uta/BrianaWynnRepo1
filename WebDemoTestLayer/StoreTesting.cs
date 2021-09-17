using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoBusinessLayer.Interfaces;
using WebAPIDemoBusinessLayer.Mappers;
using WebAPIDemoBusinessLayer.Repositories;
using WebAPIDemoBusinessLayer.ViewModels;
using WebAPIDemoDataAcess.EntityModels;
using Xunit;

namespace WebDemoTestLayer
{
    public class StoreTesting
    {
        public DbContextOptions<CoreDbContext> options { get; set; } = new DbContextOptionsBuilder<CoreDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        [Fact]
        public void AllStoreShouldReturnAllStores()
        {
            using (CoreDbContext _context = new CoreDbContext(options))
            {
                //Arrange
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                Store s1 = new Store() { Address = "a great big address" };
                Store s2 = new Store() { Address = "a great big address" };
                Store s3 = new Store() { Address = "a great big address" };

                _context.Stores.Add(s1);
                _context.Stores.Add(s2);
                _context.Stores.Add(s3);
                _context.SaveChanges();

                IStoreRepository repo = new StoreRepository(_context);

                //act

                List<Store> stores = repo.AllStore();

                Assert.Equal(3, stores.Count);


            }


        }
        [Fact]
        public void StoreOrderShouldReturnSpecificStore()
        {
            using (CoreDbContext _context = new CoreDbContext(options))
            {
                //This test is not complete
                //Arrange
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                Store s1 = new Store() { Address = "a great big address" };
                Store s2 = new Store() { Address = "a great big address" };
                Store s3 = new Store() { Address = "a great big address" };

                _context.Stores.Add(s1);
                _context.Stores.Add(s2);
                _context.Stores.Add(s3);
                _context.SaveChanges();

                IStoreRepository repo = new StoreRepository(_context);

                //act
                int getStoreAtTwo = 2;
                List<ViewStoreOrder> store = repo.StoreOrder(getStoreAtTwo);

                Assert.NotNull(store);
                


            }


        }

        [Fact]
        public void MapperToStore()
        {
            //Arrange
            ViewStore c = new ViewStore() { Address = "1408 South Jefferson Avenue" };

            //Act
            IStoreMapper mapper = new StoreMapper();
            Store c1 = mapper.ViewStoreToStore(c);
            //Assert
            Assert.Equal("1408 South Jefferson Avenue", c1.Address);
        }

        [Fact]
        public void MapperToViewStore()
        {
            //Arrange
            Store c = new Store() { Address = "1408 South Jefferson Avenue" };

            //Act
            IStoreMapper mapper = new StoreMapper();


            ViewStore c1 = mapper.StoreToViewStore(c);
            //Assert
            Assert.Equal("1408 South Jefferson Avenue", c1.Address);
        }


    }//eoc
}//eon
