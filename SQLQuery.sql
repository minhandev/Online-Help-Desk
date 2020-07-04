create database dbHelpDesk
go
use dbHelpDesk
go

create table Account
(
	Id int identity(1000,1) not null,
	Username varchar(200) not null,
	Password varchar(200) not null,
	Fullname varchar(200) not null,
	Status bit not null,
	Email varchar(200) not null,
	RoleId int,
	Primary key(Id)
)
go
create table Category
(
	Id int identity(1000,1) not null,
	Name nvarchar(200) not null,
	Status bit not null,
	primary key(Id)
)
go
create table Discussion
(
	Id int identity(1000,1) not null,
	Content text,
	CreateDate date,
	TicketId int,
	AccountId int,
	Primary key(Id)
)
go
create table Period
(
	Id int identity(1000,1) not null,
	Name nvarchar(200) not null,
	Status bit not null,
	primary key(Id)
)
go
create table Role
(
	Id int identity(1000,1) not null,
	Name nvarchar(200) not null,
	primary key(Id)
)
go
create table Status
(
	Id int identity(1000,1) not null,
	Name nvarchar(200) not null,
	Display bit not null,
	primary key(Id)
)
go
create table Photo
(
	Id int identity(1000,1) not null,
	Name nvarchar(200) not null,
	TicketId int not null,
	primary key(Id)	
)
go
create table Ticket
(
	Id int identity(1000,1) not null,
	Title nvarchar(200) not null,
	Description text not null,
	CreateDate date not null,
	StatusId int not null,
	CategoryId int not null,
	PeriodId int not null,
	EmployeeId int,
	SupporterId int not null, 
	primary key(Id)
)
go
alter table Ticket add constraint fk_Ticket_Period foreign key (PeriodId) references Period(Id)
alter table Ticket add constraint fk_Ticket_Category foreign key (CategoryId) references Category(Id)
alter table Photo add constraint fk_Photo_Ticket foreign key (TicketId) references Ticket(Id)
alter table Discussion add constraint fk_Discussion_Ticket foreign key (TicketId) references Ticket(Id)
alter table Ticket add constraint fk_Ticket_Account foreign key (SupporterId) references Account(Id)
alter table Ticket add constraint fk_Ticket_Status foreign key (StatusId) references Status(Id)
go
alter table Discussion add constraint fk_Discussion_Account foreign key (AccountId) references Account(Id)
go
alter table Account add constraint fk_Role_Account foreign key (RoleId) references Role(Id)