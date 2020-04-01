create table Agent_igroup4 (
    AgentID int identity(1,1) not null,
    firstName nvarchar (255) not null,
    sureName nvarchar (255) not null,
	email varchar(255) not null,
    password1 varchar(255) not null,
	phoneNumber int not null,
	agencyName nvarchar(255),
	primary key (AgentID)
);



select * from Agent_igroup4

drop table Agent_igroup4
