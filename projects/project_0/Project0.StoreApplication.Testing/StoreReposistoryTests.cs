using System;
using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing
{
  public class StoreRepositoryTests
  {
    [Fact]

    public void Test_StoreCollection()
    {
      //arrange = instance of the entity to test
      var sut = new StoreRepository();

      // act = execute sut for data
      var actual = sut.Stores;

      //assert = test itself
      Assert.NotNull(actual);
    }

    public void Test_OneStore()
    {
      var sut = new StoreRepositoryTests();

      var store = sut.GetStore();

      Assert.NotNull(store);
    }
  }
}