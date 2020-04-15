create table PromotedAttraction_igroup4 (
    attracionID varchar (30) not null,
	ordersQuantity int DEFAULT 0,
    promoted bit DEFAULT 0,
	primary key (attracionID)
);

UPDATE PromotedAttraction_igroup4 SET promoted = 0 WHERE attracionID = 'Kalverstraat';

select * from PromotedAttraction_igroup4

select COUNT(attracionID) from PromotedAttraction_igroup4 where attracionID='kkk'


drop table PromotedAttraction_igroup4

select COUNT(attracionID) as count_ from PromotedAttraction_igroup4 where attracionID='Kalverstraat'