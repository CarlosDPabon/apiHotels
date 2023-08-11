/****** Script for SelectTopNRows command from SSMS  ******/
use HOTEL;


Insert into IdentificationType (identificationName)
VALUES ('Cédula'),
('Pasaporte');

Insert into IdentificationType (identificationName)
VALUES ('Cédula'),
('Pasaporte');

INSERT INTO contactEmergency (userid, firstName, lastName, phonenumber)
VALUES (1, 'adolf', 'Furer', 321456987); 

INSERT INTO dbo.person(identificationId, numberidentification, firstname, lastname, birthName, gender, email, phoneNumber)
VALUES (2, 123456, 'Carlos', 'Pabon', '2023-08-07', 'Hombre', 'correo@gmail.com', 321654);

INSERT INTO dbo.UserInfo (personId, userName, password)
VALUES (1, 'usercarlos', 'contraseña');

select * from dbo.hotel;
select * from dbo.room;
select * from dbo.userinfo;
select * from dbo.person;
select * from dbo.contactemergency;

drop table dbo.UserInfo;
drop table dbo.hotel_user;

drop table dbo.hotel;
drop table dbo.room;
drop table dbo.contactEmergency;
drop table dbo.Booking;
drop table dbo.Booking_Person;
drop table dbo.person;