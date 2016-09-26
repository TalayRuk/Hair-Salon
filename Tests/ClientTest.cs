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
    public void T1_GetAll_IsDatabaseEmpty()
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
      Client clientOne = new Client("Joe Lee", 2061234567, 1);
      Client clientTwo = new Client("Joe Lee", 2061234567, 1);

      //Assert
      Assert.Equal(clientOne, clientTwo);
    }

    [Fact]
    public void T3_Save_DoesSaveWork()
    {
      //Arrange
      Client newClient = new Client("Joe Lee", 2061234567, 1);

      //Act
      newClient.Save();
      Client result = Client.GetAll()[0];

      //Assert
      Assert.Equal(newClient, result);
    }

    [Fact]
    public void T4_Save_GetId_DoesSaveIdToClient()
    {
      //Arrange
      Client testClient = new Client("Joe Lee", 2061234567, 1);
      testClient.Save();

      //Act
      Client savedClient = Client.GetAll()[0];

      int testId = testClient.GetId();
      int resultId = savedClient.GetId();

      //Assert
      Assert.Equal(testId, resultId);
    }

    [Fact]
    public void T5_Find_DoesFindWork()
    {
      //Arrange
      Client testClient = new Client("Joe Lee", 2061234567, 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.Equal(testClient, foundClient);
    }

    [Fact]
    public void T6_DeleteOne()
    {
      //Arrange
      Client clientOne = new Client("Joe Lee", 2061234567, 1);
      Client clientTwo = new Client("Col Day", 2061231111, 1);
      clientOne.Save();
      clientTwo.Save();

      //Act
      clientOne.DeleteOne();
      List<Client> result = Client.GetAll();

      //Assert
      Assert.Equal(1, result.Count);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
