create table ToDoList_igroup4 (
    agent_ID int not null,
    taskID int identity(1,1) not null,
    taskText varchar(100) not null,
	completed int not null default 0,
	primary key (taskID)
);

drop table ToDoList_igroup4
select * from ToDoList_igroup4