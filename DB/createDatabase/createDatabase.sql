DROP DATABASE HOTEL;
CREATE DATABASE HOTEL;
USE HOTEL;

CREATE TABLE IdentificationType(
identificationId INT IDENTITY PRIMARY KEY,
identificationName VARCHAR(50) NOT NULL
);

CREATE TABLE Person (
personId INT IDENTITY PRIMARY KEY,
identificationId INT NOT NULL,
numberIdentification INT UNIQUE NOT NULL,
firstName VARCHAR(25) NOT NULL,
lastName VARCHAR(25) NOT NULL,
birthDate DATETIME NOT NULL,
gender VARCHAR(15) NOT NULL,
email varchar(50) UNIQUE NOT NULL,
phoneNumber INT UNIQUE NOT NULL,
CONSTRAINT fk_Person_IdentificationType FOREIGN KEY (identificationId) REFERENCES IdentificationType (identificationId)
);

CREATE TABLE UserInfo (
userId INT IDENTITY PRIMARY KEY,
personId INT NOT NULL,
userName VARCHAR(15) UNIQUE NOT NULL,
password VARCHAR(15) NOT NULL,
CONSTRAINT fk_UserInfo_Person FOREIGN KEY (personId) REFERENCES Person (personId)
);

CREATE TABLE Rol(
rolId INT IDENTITY PRIMARY KEY,
rolName VARCHAR(25) NOT NULL,
);

CREATE TABLE UserInfo_Rol(
relationId INT IDENTITY PRIMARY KEY,
userId INT NOT NULL,
rolId INT NOT NULL,
);

CREATE TABLE Module(
moduleId INT IDENTITY PRIMARY KEY,
name VARCHAR(25) UNIQUE NOT NULL,
description VARCHAR(200)
);

CREATE TABLE Rol_Module(
relation INT IDENTITY PRIMARY KEY,
rolId INT NOT NULL,
moduleId INT NOT NULL,
CONSTRAINT fk_Rol_Module_Rol FOREIGN KEY (rolId) REFERENCES Rol (rolId),
CONSTRAINT fk_Rol_Module_Module FOREIGN KEY (moduleId) REFERENCES Module (moduleId)
);

CREATE TABLE Hotel(
hotelId INT IDENTITY PRIMARY KEY,
identificationId INT NOT NULL,
numberIdentification INT UNIQUE NOT NULL,
hotelName VARCHAR(25) NOT NULL,
country VARCHAR(20) NOT NULL,
ubication VARCHAR(200) NOT NULL,
phoneNumber INT UNIQUE NOT NULL,
email VARCHAR(25) UNIQUE NOT NULL,
active bit NOT NULL,
CONSTRAINT fk_Hotel_IdentificationType FOREIGN KEY(identificationId) REFERENCES IdentificationType (identificationId),
);

CREATE TABLE Room (
roomId INT IDENTITY PRIMARY KEY,
hotelId INT NOT NULL,
numberRoom int NOT NULL,
capacity INT NOT NULL,
type VARCHAR(25) NOT NULL,
ubication VARCHAR (25) NOT NULL,
price INT NOT NULL,
active BIT NOT NULL,
CONSTRAINT fk_Room_Hotel FOREIGN KEY (hotelId) REFERENCES Hotel (hotelId)
);

CREATE TABLE Tax (
taxId INT IDENTITY PRIMARY KEY,
name VARCHAR(50) NOT NULL,
active BIT NOT NULL
);

CREATE TABLE Room_Tax (
relationId INT IDENTITY PRIMARY KEY,
RoomId INT NOT NULL,
TaxID INT NOT NULL,
CONSTRAINT fk_Room_Tax_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId),
CONSTRAINT fk_Room_Tax_Tax FOREIGN KEY (TaxId) REFERENCES Tax (TaxId)
);

CREATE TABLE contactEmergency (
contactEmergencyId INT IDENTITY PRIMARY KEY,
userId INT NOT NULL,
firstName VARCHAR(25),
lastName VARCHAR(25),
phoneNumber INT NOT NULL,
CONSTRAINT fk_contactEmergency_userInfo FOREIGN KEY(userId) REFERENCES userInfo (userId)
);

CREATE TABLE Booking (
bookingId INT PRIMARY KEY,
hotelId INT NOT NULL,
roomId INT NOT NULL,
userId INT NOT NULL,
contactEmergencyId INT NOT NULL,
checkIn DATETIME NOT NULL,
checkOut DATETIME NOT NULL,
CONSTRAINT fk_Booking_Hotel FOREIGN KEY (hotelId) REFERENCES Hotel (hotelId),
CONSTRAINT fk_Booking_Room FOREIGN KEY (roomId) REFERENCES Room (roomId),
CONSTRAINT fk_Booking_contactEmergency FOREIGN KEY (contactEmergencyId) REFERENCES contactEmergency (contactEmergencyId),
CONSTRAINT fk_Booking_User FOREIGN KEY(userId) REFERENCES UserInfo (userId)
);

CREATE TABLE Booking_Person(
relationId INT IDENTITY PRIMARY KEY,
personId INT NOT NULL,
bookingId INT NOT NULL
CONSTRAINT fk_Booking_Person_Person FOREIGN KEY (personId) REFERENCES Person (personId),
CONSTRAINT fk_Booking_Person_Booking FOREIGN KEY (bookingId) REFERENCES Booking (bookingId)
);

CREATE TABLE Hotel_User (
relationId INT IDENTITY PRIMARY KEY,
userId INT NOT NULL,
hotelId INT NOT NULL,
CONSTRAINT fk_Hotel_User_UserInfo FOREIGN KEY (userId) REFERENCES UserInfo (userId),
CONSTRAINT fk_Hotel_User_Hotel FOREIGN KEY (hotelId) REFERENCES Hotel (hotelId)
);
