using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  { //this method name & class name need to match!
    public ClientTest() 
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_IsDatabaseEmpty()
    {
      //Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    //Dispose() add once write Delete()
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
