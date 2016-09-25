using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private string _firstName;
    private string _lastName;
    private int _phoneNumber;
    private int _id;
    //add StylistId
    //add constructor
    public Client(string firstName, string lastName, int phoneNumber, int id =0)
    {
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _id = id;
    }
    //Getter
    public string GetFirstName()
    {
      return _firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public int GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public int GetId()
    {
      return _id;
    }
    //Setter
    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public void SetLastName(string newLastName)
    {
      _lastName = newLastName;
    }
    public void SetPhoneNumber(int newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }

    //GetAll
    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        int clientPhone = rdr.GetInt32(3);

        Client newClient = new Client(clientFirstName, clientLastName, clientPhone, clientId);
        allClients.Add(newClient);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;
    }


    //DeleteAll
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
