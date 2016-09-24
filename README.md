# _HAIR SALON_

#### _Create a web app for a hair salon using database to store list of clients and hair stylists._

#### By _** Vichitra Pool **_

## Description

_The owner can add to a list of the stylists, and for each stylist, add clients who see that stylist. Each client only belongs to a single stylist._


## Specs

| Behavior     | Input Example  |Output Example  |
| ------------- |:-------------:| -----:|
|GetAll() return all rows present in database |2 client instances | list containing 2 clients
|GetAll().Count return Number of rows in database | no input | database empty
|Override bool Equal function return 2 same inputs with different Id | 2 same client instances | list containing 2 client's names
|Save() return input save to the list | new client instance | list containing new client
|DeleteAll() clear out all rows in database | 2 client instances | none
|Find() return specific row from database | Joe | found Joe
|DeleteOne() clear 1 specific row in database | Joe | none
|*One-to-many relationship set up
|Test Stylist **Spec 
|*CRUD functionality for each class been built in Nancy
|*RESTful routes used in Nancy


## Setup/Installation
#### Files can be cloned from https://github.com/TalayRuk/Hair-Salon.git and run in a browser (requires a server environment).

#### Using Mono in the root directory, type the following at the command prompt:

##### To install dependencies:

\>dnu restore

#### To use the database, in SQLCMD:

\>CREATE DATABASE hair_salon;

\>GO

\>USE hair_salon;

\>GO

\>CREATE TABLE stylists (id INT IDENTITY (1,1), first_name VARCHAR(255), last_name VARCHAR(255), expertise VARCHAR(255));

\>CREATE TABLE clients (id INT IDENTITY (1,1), first_name VARCHAR(255), last_name VARCHAR(255), stylist_id INT);

\>GO

#### To run the local server:

\>dnx kestrel

#### Copy: http://localhost:5004 in your browser.

## Support and contact details

Please contact the authors if you have any questions or comments.

## Technologies Used

C#, Nancy, Razor, Xunit, Database and cshtml.

### License

Copyright (c) 2016 **_Vichitra Pool_**

This software is licensed under the MIT license.

Steps

Before we start writing our code, we'll need to open SQLCMD, create a database named todo, and make a table called tasks with a primary key id and a varchar column called description:

SQLCMD -S "(localdb)\mssqllocaldb"

1> CREATE DATABASE hair_salon;
2> GO
1> USE hair_salon;
2> GO
1> CREATE TABLE clients
2> (
3>   id INT IDENTITY (1,1),
4>   c_name VARCHAR(255), c_phone INT
5> );
6> GO

Create project files .. Db class in database.cs 
-then create backup from hair_style database
-create restore hair_style_test database

Now that we've configured our application to work with a database and run tests on it, 
Start on the actual app. 
set up our test file 
using Xunit;
using System.Collections.Generic; the 
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientsTest : IDisposable
  {
    public ClientsTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test.   Cobb.  ;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Task.DeleteAll();
    }
  }
}
-In our ClientsTest constructor, we set DBConfiguration.ConnectionString to our hair_salon_test database, which overrides the DBConfiguration.ConnectionString we set in Startup.cs.

1. Now let's write our first spec, which will test that we have an empty database to start testing
2. testing the static Task.GetAll() method. 
   *Here we will want to pull out all of the tasks from the database into a list. Since we haven't saved anything yet, the list will be empty.

SQLCMD -S "(localdb)\mssqllocaldb" -d hair_style

* -add stylist database table
* -backup & restore hair_salon_tests
* -add stylist.cs 
* -add stylistTests.cs 
* -add foreign key 
     1> ALTER TABLE tasks ADD stylist_id INT;
     2> GO
      *b/c 1 stylist can have many clients 
       -one to many 
* -add 
