create table TripProfile_igroup4 (
    _id int identity(1,1) not null,
	_name varchar(255)not null,
	primary key (_id)
);
select * from TripProfile_igroup4


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
drop table Trip_igroup4

select * from countryCode_igroup4
