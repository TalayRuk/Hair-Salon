using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon
{
  public ClientTests //: IDisposable
  {
    public ClientTests() //this method name & class name need to match!
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_IsDatabaseEmpty()
    {
      //Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
    //Dispose() add once write Delete()
    //public void Dispose()
    // {
    //   Client.DeleteAll();
    // }
  }
}
