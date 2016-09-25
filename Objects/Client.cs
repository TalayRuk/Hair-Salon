using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _phoneNumber;
    //add StylistId
    //add constructor
    public Client(string name, int phoneNumber, int id =0)
    {
      _id = id;
      _name = name;
      _phoneNumber = phoneNumber;
    }
    //Getter
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetPhoneNumber()
    {
      return _phoneNumber;
    }
    //Setter
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void SetPhoneNumber(int newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    //add stylelist setter?
    //Override
    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool phoneNumberEquality = (this.GetPhoneNumber() == newClient.GetPhoneNumber());
        //add StylistId
        return (idEquality && nameEquality && phoneNumberEquality); //StylistId);
      }
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
        string clientName = rdr.GetString(1);
        int clientPhone = rdr.GetInt32(2);

        Client newClient = new Client(clientName, clientPhone, clientId);
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

    //GetHashCode
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
  }
}
