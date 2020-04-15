create table PromotedAttraction_igroup4 (
    attracionID varchar (30) not null,
	ordersQuantity int DEFAULT 0,
    promoted bit DEFAULT 0,
	primary key (attracionID)
);

select * from PromotedAttraction_igroup4

select COUNT(attracionID) from PromotedAttraction_igroup4 where attracionID='kkk'


drop table PromotedAttraction_igroup4