/****** Script for SelectTopNRows command from SSMS  ******/
use HOTEL;

INSERT INTOIdentificationType (identificationName)
VALUES ('Cédula'),
('Pasaporte');

INSERT INTO contactEmergency (userid, firstName, lastName, phonenumber)
VALUES (2, 'adolf', 'Furer', 321456987); 

INSERT INTO dbo.person(identificationId, numberidentification, firstname, lastname, birthDate, gender, email, phoneNumber)
VALUES (2, 123456, 'Carlos', 'Pabon', '2023-08-07', 'Hombre', 'correo@gmail.com', 321654);

INSERT INTO dbo.UserInfo (personId, userName, password)
VALUES (2, 'usercarlos', 'contraseña');

--INSERT INTO dbo.contactemergency ()

INSERT INTO dbo.hotel_user(userid, hotelid)
VALUES (2, 1);
select * from dbo.hotel;
select * from dbo.Hotel_User;
select * from dbo.room;
select * from dbo.userinfo;
select * from dbo.person;
select * from dbo.contactemergency;
select * from booking;
select * from booking_person;

drop table dbo.UserInfo;
drop table dbo.hotel_user;

drop table dbo.hotel;
drop table dbo.room;
drop table dbo.contactEmergency;
drop table dbo.Booking;
drop table dbo.Booking_Person;
drop table dbo.person;