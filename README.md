# _HAIR SALON_

#### _Create an app for a hair salon._

#### By _** Vichitra Pool **_

## Description

_The owner can add to a list of the stylists, and for each stylist, add clients who see that stylist. Each client only belongs to a single stylist._


## Specs

| Behavior     | Input Example  |Output Example  |
| ------------- |:-------------:| -----:|
|GetAll() return all row present in database |2 client instances | list containing 2 clients
|GetAll().Count return Number of rows in database | no input | database empty
|Override bool Equal function return 2 same inputs with different Id | 2 same client instances | list containing 2 client's names 
|Save() return input save to the list | new client instance | list containing new client 
|

## Setup/Installation Requirements

#### In SQLCMD:
* >CREATE DATABASE hair_salon;
* >GO
* >USE hair_salon;
* >GO
* >CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
* >CREATE TABLE clients (id INT IDENTITY(1,1), client_name VARCHAR(255));
* >GO

## Support and contact details

Please contact the authors if you have any questions or comments.

## Technologies Used

C#, Nancy, Razor, Xunit, Database and cshtml.

### License

Copyright (c) 2016 **_Vichitra Pool_**

This software is licensed under the MIT license.
