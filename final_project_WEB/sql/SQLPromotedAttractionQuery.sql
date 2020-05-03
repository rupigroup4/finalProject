drop table PromotedAttraction_igroup4
create table PromotedAttraction_igroup4 (
    attracionID varchar (30) not null,
	ordersQuantity int DEFAULT 0,
    promoted bit DEFAULT 0,
	tripProfile varchar(10)DEFAULT '0',
	cityName varchar(255) not null,
	primary key (attracionID)
);
	select * from PromotedAttraction_igroup4 
	select tripProfile from PromotedAttraction_igroup4 where attracionID='ggg'