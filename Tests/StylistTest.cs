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
      int resultId = savedStylist.GetId();

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
      Client clientOne = new Client("Joe Lee", 2061234567, testStylist.GetId());
      Client clientTwo = new Client("Col Day", 2061231111, testStylist.GetId());
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
