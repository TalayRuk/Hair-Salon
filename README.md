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
