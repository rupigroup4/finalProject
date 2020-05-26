drop table PromotedAttraction_igroup4
create table PromotedAttraction_igroup4 (
	agent_ID int not null,
    attractionID varchar (30) not null,
    rate int,	
	cityName varchar(255) not null,
	ordersQuantity int DEFAULT 0,
	_2 int DEFAULT '0',
	_3 int DEFAULT '0',
	_4 int DEFAULT '0',
	_5 int DEFAULT '0',
	_6 int DEFAULT '0',
	CONSTRAINT PK_Promoted PRIMARY KEY (agent_ID,attractionID)
);
select * from PromotedAttraction_igroup4


select COUNT(*) as count from PromotedAttraction_igroup4 where agent_ID=1 AND attractionID='Kalverstraat'

SELECT * FROM PromotedAttraction_igroup4 where Agent_ID=1

    select * from TripProfile_igroup4
	select * from Trip_igroup4 
	select * from PromotedAttraction_igroup4 
	UPDATE PromotedAttraction_igroup4 SET _3= 1 WHERE attracionID = 'Kalverstraat'

	select COUNT(*) as count from PromotedAttraction_igroup4 where agent_ID=1 AND attracionID='Kalverstraat'
	INSERT INTO PromotedAttraction_igroup4 (attracionID,rate,cityName)Values('W__145953534','1','Amsterdam')

	INSERT INTO PromotedAttraction_igroup4 (attracionID,rate,cityName,agent_ID)Values('W__44508814','3','Amsterdam','1')