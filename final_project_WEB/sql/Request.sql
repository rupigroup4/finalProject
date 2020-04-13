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

select * from Request_igroup4;



SELECT  * FROM Request_igroup4
LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id
LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID
LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID
where status_='new' AND Customer_igroup4.AgentID='1'

SELECT Request_igroup4.requestID, Request_igroup4.status_ FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Customer_igroup4.AgentID=1

SELECT Customer_igroup4.firstName, Customer_igroup4.sureName FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where requestID =3

