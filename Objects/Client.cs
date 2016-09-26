using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private string _name;
    private int _phone;
    private int _id;
    //add StylistId
    //add constructor
    public Client(string name, int phone, int id =0)
    {
      _name = name;
      _phone = phone;
      _id = id;
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
    public int GetPhone()
    {
      return _phone;
    }
    //Setter
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void SetPhone(int newPhone)
    {
      _phone = newPhone;
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
        bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
        //add StylistId
        return (idEquality && nameEquality && phoneEquality); //StylistId);
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

    //Save
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (first_last_name, phone_number) OUTPUT INSERTED.id VALUES (@ClientName, @ClientPhone);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ClientPhone";
      phoneParameter.Value = this.GetPhone();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(phoneParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    //Find()
    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);

      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id.ToString();

      cmd.Parameters.Add(clientIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientId = 0;
      string foundClientName = null;
      int foundClientPhone = 0;
      //int foundClientStylistId = 0;

      while (rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundClientPhone = rdr.GetInt32(2);
      }
      Client foundClient = new Client(foundClientName, foundClientPhone, foundClientId); //,foundClientStylistId

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      //when there's no return foundClient ..error cs0161 occur
      return foundClient;
    }

    //DeleteOne
    public void DeleteOne()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);

      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = this.GetId();

      cmd.Parameters.Add(clientIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    //DeleteAll
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();

      if (conn != null)
      {
        coon.Close();
      }
    }

    //GetHashCode
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
  }
}
