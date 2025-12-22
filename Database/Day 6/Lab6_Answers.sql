create table Departement
(
	deptId int primary key,
	deptName varchar(50),
	location loc
) 
on SecondaryFG

sp_addtype loc, 'char(2)'
create default def1	as 'NY'
create rule locCheck as @x in('NY','DS','KW')

sp_bindrule	locCheck, loc
sp_bindefault def1, loc

create table Employee
(
	empNo int,
	empFname varchar(50) not null,
	empLname varchar(50) not null,
	deptNo int,
	salary int,

	constraint c1 primary key (empNo),
	constraint c2 foreign key (deptNo) references Departement(deptId),
	constraint c3 unique(salary),

)

create rule r2 as @x<6000

sp_bindrule r2 ,'Employee.salary'

alter table worksOn add constraint c4 primary key (empNO, projectNo)
alter table workson add constraint c5 foreign key (empNo) references Employee(empNo)
alter table workson add constraint c6 foreign key (projectNo) references Project(projectNo)

insert into Departement
values(1, 'Research', 'NY'),
	(2, 'Accounting', 'DS'),
	(3, 'Makerting', 'KW')

insert into Employee
values(25348, 'Mathew', 'Smith', 3, 2500),
	(10102, 'Ann', 'Jones', 3, 3000),
	(18316, 'John', 'Barrimore', 1, 2400),
	(29346, 'James', 'James', 2, 2800)

insert into Project
values(1, 'Apollo', 120000),
	(2, 'gemini', 95000)

insert into worksOn
values(10102, 1, 'Analyst', '10-10-2006'),
	(10102, 2, 'Manager', '1-1-2012')


------------------- Testing
insert into worksOn
values(11111, 1, 'Analyst', '10-10-2006')
--The INSERT statement conflicted with the FOREIGN KEY constraint "c5".
--The conflict occurred in database "SD",table "dbo.Employee", column 'empNo'.

update worksOn set empNo = 11111 where empNo=10102
--The same as above statement because the value of the empNo is a foreign key
update Employee set empNo = 22222 where empNo=10102

delete from Employee where empNo = 10102

---------------- Table Modification
alter table Employee add telephoneNo varchar(20)

alter table Employee drop column telephoneNo

-------------------------- 2.
create schema Company
create schema HR

alter schema Company transfer dbo.Departement

alter schema HR transfer dbo.Employee

------------------------- 3.
SELECT *
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Employee'

------------------------- 4.
create synonym Emp for HR.Employee
select *
from Employee
select *
from HR.Employee
select *
from Emp
select *
from HR.Emp

------------------------ 5.
UPDATE Project
SET Budget = Budget * 1.10
WHERE ProjectNo IN (SELECT ProjectNo
FROM worksOn
WHERE EmpNo = 10102 AND Job = 'Manager')

------------------------ 6.
update Company.Departement set deptName = 'Sales' where deptId = (select deptNo
from HR.Employee
where empFname='James')

------------------------ 7.

update worksOn set enterDate = '12-12-2007' 
from worksOn inner join EMP on EMP.empNo = worksOn.empNo
	inner join Company.Departement on Company.Departement.deptId = EMP.deptNo
where worksOn.projectNo = 1 and Company.Departement.deptName = 'Sales'

------------------------ 8.

delete from worksOn where empNo in (select EMP.empNo
from EMP inner join Departement on EMP.deptNo = Departement.deptNo
where Departement.location = 'KW')

------------------------ 9.

USE master;
CREATE LOGIN ITIStud WITH PASSWORD = 'Azouz@123';

USE ITI;
CREATE USER ITIStud FOR LOGIN ITIStud;

GRANT SELECT, INSERT ON Student TO ITIStud;
GRANT SELECT, INSERT ON Course TO ITIStud;

-- Step 4: Explicitly Deny UPDATE and DELETE
DENY UPDATE, DELETE ON Student TO ITIStud;
DENY UPDATE, DELETE ON Course TO ITIStud;