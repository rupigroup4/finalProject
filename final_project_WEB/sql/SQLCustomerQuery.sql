create table Customer_igroup4 (
    CustomerID int identity(1,1) not null,
    firstName nvarchar (255) not null,
    sureName nvarchar (255) not null,
	phoneNumber varchar (20) not null,
	gender char(1) not null, 
	birthday varchar(10) not null,
	email varchar(255) not null,
	img varchar(1000),
	joinDate varchar(10) not null,
	pnToken nvarchar(200),
	authToken nvarchar(200),
	AgentID int,
	primary key (CustomerID),
	foreign key (AgentID) REFERENCES Agent_igroup4(AgentID)
);

ALTER TABLE Customer_igroup4
ADD pnToken nvarchar(200) ;

select * from Customer_igroup4
DELETE FROM Customer_igroup4 WHERE CustomerID='1003';


Alter table Customer_igroup4
Alter column birthday varchar(10)

drop table Customer_igroup4

select * from Agent_igroup4

SELECT * FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=1;
SELECT * FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=1