create table Customer_igroup4 (
    CustomerID int identity(1,1) not null,
    firstName nvarchar (255) not null,
    sureName nvarchar (255) not null,
	phoneNumber int not null,
	gender char(1) not null, 
	birthday varchar(10) not null,
	email varchar(255) not null,
	img varchar(1000),
	joinDate varchar(10) not null,
	AgentID int,
	primary key (CustomerID),
	foreign key (AgentID) REFERENCES Agent_igroup4(AgentID)
);

ALTER TABLE Customer_igroup4
ADD pnToken nvarchar(200) ;

select * from Customer_igroup4

Alter table Customer_igroup4
Alter column birthday varchar(10)

drop table Customer_igroup4

select * from Agent_igroup4
