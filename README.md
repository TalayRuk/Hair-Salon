# _HAIR SALON_

#### _Create an app for a hair salon._

#### By _** Vichitra Pool **_

## Description

_The owner can add to a list of the stylists, and for each stylist, add clients who see that stylist. Each client only belongs to a single stylist._


## Specs

| Behavior     | Input Example  |Output Example  |
| ------------- |:-------------:| -----:|
|if the two are the same, no one wins | rock v rock | "DRAW" |
| if the two are different, the winner is displayed | Rock v. Scissors | Rock wins |
| if the two are different, the winner is displayed | Rock v. Paper | Paper wins |
| if the two are different, the winner is displayed | Paper v. Scissors | Scissors wins |

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
