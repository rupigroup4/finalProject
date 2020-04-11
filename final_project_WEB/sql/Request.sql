create table Request_igroup4 (
    _requestID int identity(1,1) not null,
	_date_time varchar(10) not null,
    _numTickets int not null,
    _status varchar(20) not null,
	pdfFile varchar(max),
    _TripID  int not null,
	primary key (_requestID),
	foreign key (_TripID) REFERENCES Trip_igroup4(_id)
);

drop table Request_igroup4;

select * from Request_igroup4;

SELECT COUNT(requestID) as count_ FROM Request_igroup4 where _status='new'