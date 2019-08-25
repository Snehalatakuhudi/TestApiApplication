
--Create sample database
CREATE DATABASE TestAppDb
GO
--use Sample database
USE TestAppDb
GO


Create Table UserInfo(UserId int Primary Key identity(1,1),
  Name varchar(50),
  Email varchar(50),
  Password varchar(Max),
  Age int,
  DOB Date, 
  Location varchar(50), 
  UsrType varchar(50))


  Create Table UserData(id int Primary Key identity(1,1),
  Skill varchar(50), 
  Experience varchar(50) ,
  Certification  varchar(50),
  UserId int Foreign Key REFERENCES  UserInfo(UserId))
    