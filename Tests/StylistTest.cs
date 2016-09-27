using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylelistTest : IDisposable
  { //this method name & class name need to match!
    public StylelistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void T1_GetAll_IsStylistDatabaseEmpty()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_Equal_ReturnsTrueIfPropretiesAreSame()
    {
      //Arrange, Act
      Stylist stylistOne = new Stylist("Amy Zee");
      Stylist stylistTwo = new Stylist("Amy Zee");

      //Assert
      Assert.Equal(stylistOne, stylistTwo);
    }

    [Fact]
    public void T3_Save_DoesStylistSaveWork()
    {
      //Arrange
      Stylist newStylist = new Stylist("Amy Zee");

      //Act
      newStylist.Save();
      Stylist result = Stylist.GetAll()[0];

      //Assert
      Assert.Equal(newStylist, result);
    }

    [Fact]
    public void T4_Save_GetId_DoesSaveIdToStylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Amy Zee");
      testStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];

      int testId = testStylist.GetId();
      Console.WriteLine(testId);
      int resultId = savedStylist.GetId();
      Console.WriteLine(resultId);

      //Assert
      Assert.Equal(testId, resultId);
    }

    [Fact]
    public void T5_Find_DoesFindStylistWork()
    {
      //Arrange
      Stylist testStylist = new Stylist("Amy Zee");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void T6_GetClients_RetrievesAllClientsWithStylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Amy Zee");
      testStylist.Save();

      //Act
      Client clientOne = new Client("Joe Lee", testStylist.GetId());
      Client clientTwo = new Client("Col Day", testStylist.GetId());
      clientOne.Save();
      clientTwo.Save();

      List<Client> testClientList = new List<Client> {clientOne, clientTwo};
      List<Client> resultClientList = testStylist.GetClients();

      //Assert
      Assert.Equal(testClientList, resultClientList);
    }

    [Fact]
    public void T7_Update_UpdateStylist()
    {
      //Arrange
      string name = "Jane May";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Ike Lee";

      //Act
      testStylist.Update(newName);

      string result = testStylist.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void T8_Delete_DeleteStylistFromDatabase()
    {
      //Arrange
      string name1 = "Jane May";
      Stylist testStylist1 = new Stylist(name1);
      testStylist1.Save();

      string name2 = "Ike Lee";
      Stylist testStylist2 = new Stylist(name2);
      testStylist2.Save();

      Client testClient1 = new Client("Mary Lee", testStylist1.GetId());
      testClient1.Save();
      Client testClient2 = new Client("Dan Dan", testStylist2.GetId());
      testClient2.Save();

      //Act
      testStylist1.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist2};

      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};

      //Assert
      Assert.Equal(testStylistList, resultStylists);
      Assert.Equal(testClientList, resultClients);
    }
    // [Fact]
    // public void T6_DeleteOne()
    // {
    //   //Arrange
    //   Stylist stylistOne = new Stylist("Amy Zee");
    //   Stylist stylistTwo = new Stylist("Lila Ray");
    //   stylistOne.Save();
    //   stylistTwo.Save();
    //
    //   //Act
    //   stylistOne.DeleteOne();
    //   List<Stylist> result = Stylist.GetAll();
    //
    //   //Assert
    //   Assert.Equal(1, result.Count);
    // }

    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
  }
}
