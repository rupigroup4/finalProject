create table ToDoList_igroup4 (
    agent_ID int not null,
    taskID int identity(1,1) not null,
    taskText varchar(255) not null,
	completed int not null default 0,
	primary key (taskID)
);

drop table ToDoList_igroup4
select * from ToDoList_igroup4

DELETE FROM ToDoList_igroup4 WHERE taskID=1;

update ToDoList_igroup4 set completed =1 where taskID = 19 and agent_ID=1;

INSERT INTO ToDoList_igroup4 (agent_ID,TaskText) 
OUTPUT Inserted.taskID
Values(1, 'dsasdaasd');

INSERT INTO ToDoList_igroup4 (agent_ID,TaskText) OUTPUT Inserted.taskID (1, 'שלום');

INSERT INTO ToDoList_igroup4 (agent_ID,TaskText) OUTPUT Inserted.taskID Values('1', 'שלככככום')