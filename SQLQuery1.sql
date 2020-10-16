CREATE TABLE Customer (
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	PersonNr char(10) not null,
	Adress nvarchar(50) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null,
	PhoneNr char(10) not null
)

CREATE TABLE Car (
	Id int not null identity(1,1) primary key,
	Model nvarchar(50) not null,
	YearModel char(4) not null,
	RegNr char(6) not null
)
GO

CREATE TABLE [Order] (
	Id int not null identity(1,1) primary key,
	OrderDate datetime not null,
	CustomerId int not null references Customer(Id)
)
GO

CREATE TABLE CarOrder (
	OrderId int not null references [Order](Id),
	CarId int not null references Car(Id),
	RentalDays int not null

	primary key (OrderId, CarId)
)