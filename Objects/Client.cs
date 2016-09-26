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
    private int _phone;
    private int _stylistId;
    //add constructor
    public Client(string name, int phone, int stylistId, int id =0)
    {
      _id = id;
      _name = name;
      _phone = phone;
      _stylistId = stylistId;
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
    public int GetStylistId()
    {
      return _stylistId;
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
    public void SetStylistId(int newStylistId)
    {
      _stylistId = newStylistId;
    }
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
        //add stylistEquality
        bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && nameEquality && phoneEquality && stylistEquality); //stylistEquality);
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
        //add clientStylistId
        int clientStylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientPhone, clientStylistId, clientId);
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
      //add stylist_id & @ClientStylistId
      SqlCommand cmd = new SqlCommand("INSERT INTO clients (first_last_name, phone_number, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientPhone, @ClientStylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ClientPhone";
      phoneParameter.Value = this.GetPhone();
      //add ClientStylistId
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@ClientStylistId";
      stylistIdParameter.Value = this.GetStylistId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(phoneParameter);
      //add stylistId
      cmd.Parameters.Add(stylistIdParameter);

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
      int foundClientStylistId = 0;


      while (rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundClientPhone = rdr.GetInt32(2);
        foundClientStylistId = rdr.GetInt32(3);
      }
      Client foundClient = new Client(foundClientName, foundClientPhone, foundClientStylistId, foundClientId); //,foundClientStylistId

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
        conn.Close();
      }
    }

    //GetHashCode
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
  }
}
