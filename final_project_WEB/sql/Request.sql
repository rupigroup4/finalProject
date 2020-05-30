create table Request_igroup4 (
    requestID int identity(1,1) not null,
	date_time varchar(10) not null,
    numTickets int not null,
    status_ varchar(20) not null,
	pdfFile varchar(max),
    TripID  int not null,
	primary key (requestID),
	foreign key (TripID) REFERENCES Trip_igroup4(_id)
);

create table ArchivesRequest_igroup4 (
    archivesID int identity(1,1) not null,
	requestID int not null,
	date_time varchar(10) not null,
    numTickets int not null,
    status_ varchar(20) not null,
	pdfFile varchar(max),
    TripID  int not null,
	attractionId varchar (100) not null,
	attractionName varchar (100) not null,
	customerId int,
	primary key (archivesID),
);
drop table ArchivesRequest_igroup4
select * from ArchivesRequest_igroup4;
select * from Request_igroup4;

INSERT INTO ArchivesRequest_igroup4 (requestID ,date_time , numTickets , status_,TripID,attractionId,attractionName,customerId) Values('13','20/05/2020','4','success','6','W__31858826','Anne Frank House','1000')

SELECT * FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=1;


SELECT  * FROM Request_igroup4
LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id
LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID
LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID
where status_='new' AND Customer_igroup4.AgentID='1'

SELECT Request_igroup4.requestID, Request_igroup4.status_ FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Customer_igroup4.AgentID=1

SELECT Customer_igroup4.firstName, Customer_igroup4.sureName FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where requestID =3

