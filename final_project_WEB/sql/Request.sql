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

drop table Request_igroup4;

select * from Request_igroup4;



SELECT  COUNT(requestID) as count_ FROM Request_igroup4
LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id
LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID
LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID
where status_='new' AND Customer_igroup4.AgentID='1'