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
      Stylist stylistOne = new Stylist("Amy Zee", 2061234567, 1);
      Stylist stylistTwo = new Stylist("Amy Zee", 2061234567, 1);

      //Assert
      Assert.Equal(stylistOne, stylistTwo);
    }

    [Fact]
    public void T3_Save_DoesStylistSaveWork()
    {
      //Arrange
      Stylist newStylist = new Stylist("Amy Zee", 2061234567, 1);

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
      Stylist testStylist = new Stylist("Amy Zee", 2061234567, 1);
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
      Stylist testStylist = new Stylist("Amy Zee", 2061234567, 1);
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }

    // [Fact]
    // public void T6_DeleteOne()
    // {
    //   //Arrange
    //   Stylist stylistOne = new Stylist("Amy Zee", 2061234567, 1);
    //   Stylist stylistTwo = new Stylist("Lila Ray", 2061231111, 1);
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
