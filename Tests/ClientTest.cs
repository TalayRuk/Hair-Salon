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
    public void T1_IsDatabaseEmpty()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_Equal_ReturnsTrueIfPropretiesAreSame()
    {
      //Arrange, Act
      Client client1 = new Client("Joe Lee", 2061234567);
      Client client2 = new Client("Joe Lee", 2061234567);

      //Assert
      Assert.Equal(client1, client2);
    }

    [Fact]
    public void T3_DoesSaveWork()
    {
      //Arrange
      Client newClient = new Client("Joe Lee", 2061234567);

      //Act
      newClient.Save();
      Client result = Client.GetAll()[0];

      //Assert
      Assert.Equal(newClient, result);
    }

    [Fact]
    public void T4_DoesSaveIdToClient()
    {
      //Arrange
      Client testClient = new Client("Joe Lee", 2061234567);
      testClient.Save();

      //Act
      Client savedClient = Client.GetAll()[0];

      int testId = testClient.GetId();
      int resultId = savedClient.GetId();

      //Assert
      Assert.Equal(testId, resultId);
    }


    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
