create table Agent_igroup4 (
    AgentID int identity(1,1) not null,
    firstName nvarchar (255) not null,
    sureName nvarchar (255) not null,
	email varchar(255) not null,
    password1 varchar(255) not null,
	phoneNumber varchar(20) not null,
	agencyName nvarchar(255),
	primary key (AgentID)
);

select * from Agent_igroup4 where AgentID='2'

SELECT  COUNT(requestID) as count_ FROM Request_igroup4
LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id
LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID
LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID
where status_='new' AND Customer_igroup4.AgentID='1'

drop table Agent_igroup4

ALTER TABLE Agent_igroup4
ALTER COLUMN phoneNumber varchar(20);


SELECT COUNT(requestID) as count_ FROM Request_igroup4 LEFT JOIN Trip_igroup4 ON Request_igroup4.TripID = Trip_igroup4._id LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Customer_igroup4.AgentID=2



ALTER TABLE Agent_igroup4
ADD phoneNumber varchar(20);