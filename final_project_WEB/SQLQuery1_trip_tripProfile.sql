create table TripProfile_igroup4 (
    _id int identity(1,1) not null,
	_name varchar(255)not null,
	primary key (_id)
);



create table Trip_igroup4 (
    _id int identity(1,1) not null,
	_destination varchar(255)not null,
	_depart varchar(10) not null,
	_retern varchar(10) not null
	primary key (_id)
);

