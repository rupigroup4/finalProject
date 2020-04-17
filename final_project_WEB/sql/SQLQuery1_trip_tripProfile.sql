create table TripProfile_igroup4 (
    _id int identity(1,1) not null,
	_name varchar(255)not null,
	primary key (_id)
);

select * from Trip_igroup4



create table Trip_igroup4 (
    _id int identity(1,1) not null,
	_id_customer int not null,
	_destination varchar(255)not null,
	_depart varchar(10) not null,
	_return varchar(10) not null,
	_id_TripProfile int not null,
	primary key (_id),
	foreign key (_id_TripProfile) REFERENCES TripProfile_igroup4(_id),
	foreign key (_id_customer) REFERENCES Customer_igroup4(CustomerID)
);

select * from Trip_igroup4
SELECT COUNT(requestID) as count_ FROM Request_igroup4 where status_='new'

select * from countryCode_igroup4

SELECT * FROM Trip_igroup4 LEFT JOIN Customer_igroup4 ON Trip_igroup4._id_customer = Customer_igroup4.CustomerID LEFT JOIN Agent_igroup4 ON Customer_igroup4.AgentID = Agent_igroup4.AgentID where Agent_igroup4.AgentID=1
ALTER TABLE Trip_igroup4
ADD pdf_Flightticket varchar(max);

INSERT INTO Trip_igroup4 (_id_customer,_destination,_depart,_return,_id_TripProfile)Values('1000', 'Berlin','2020-04-16', '2020-04-22','1')