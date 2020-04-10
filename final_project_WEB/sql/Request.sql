create table Request_igroup4 (
    _requestID int identity(1,1) not null,
	_date_time varchar(10) not null,
    _numTickets int not null,
    _status varchar(20) not null,
    _TripID  int not null,
	primary key (_requestID),
	foreign key (_TripID) REFERENCES Trip_igroup4(_id)
);
