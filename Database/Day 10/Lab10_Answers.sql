---1.
-- Create a cursor for Employee table that increases Employee salary by
-- 10% if Salary <3000 and increases it by 20% if Salary >=3000. Use company DB
DECLARE updateSalaryCursor CURSOR
for select Salary
from HR.Employee
for
update
DECLARE @salary int
OPEN updateSalaryCursor
FETCH updateSalaryCursor into @salary
while @@FETCH_STATUS = 0
    BEGIN
    if @salary < 3000
            UPDATE HR.Employee set Salary = @salary*1.1
            where current of updateSalaryCursor
    else
            UPDATE HR.Employee set Salary = @salary*1.2
            where current of updateSalaryCursor
    fetch updateSalaryCursor into @salary
END
CLOSE updateSalaryCursor
DEALLOCATE updateSalaryCursor

---2.
-- Display Department name with its manager name using cursor. Use ITI DB
DECLARE printDeptNameAndManager CURSOR
for select D.Dept_Name , I.Ins_Name
from Department D INNER JOIN Instructor I on D.Dept_Manager = I.Ins_Id
for
read
only
declare @resTable TABLE(deptName VARCHAR(20),
    managerName VARCHAR(20))
declare @deptName VARCHAR(20), @managerName VARCHAR(20)
open printDeptNameAndManager
FETCH printDeptNameAndManager into @deptName, @managerName
WHILE @@FETCH_STATUS = 0
BEGIN
    insert into @resTable
    values
        (@deptName, @managerName)
    FETCH printDeptNameAndManager into @deptName, @managerName
END
CLOSE printDeptNameAndManager
DEALLOCATE printDeptNameAndManager
SELECT *
from @resTable
---3.
-- Try to display all students first name in one cell separated by comma. Using Cursor 
DECLARE printStudentsNames CURSOR
for select S.St_Fname
from Student S
for
READ
ONLY
declare @fName VARCHAR(20), @allStudentsNames VARCHAR(300)
open printStudentsNames
FETCH printStudentsNames into @fname
while @@FETCH_STATUS = 0
BEGIN
    set @allStudentsNames = CONCAT(@allStudentsNames, ', ', @fName)
    fetch printStudentsNames into @fname
END
select @allStudentsNames
close printStudentsNames
DEALLOCATE printStudentsNames

---4.
-- Create a sequence object that allow values from 1 to 10 without cycling
-- in a specific column and test it.
CREATE SEQUENCE mySeq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 10
    NO CYCLE;

CREATE TABLE SeqTest
(
    ID INT PRIMARY KEY,
    Name VARCHAR(20)
);

INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Ali');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');
INSERT INTO SeqTest
    (ID, Name)
VALUES
    (NEXT VALUE FOR mySeq, 'Azouz');

SELECT *
FROM SeqTest;

---5.
-- Create snapshot of adventureworks_db and test it
create DATABASE advWorkSnapshot
on(
    name='AdventureWorks2012_Data',
    FILENAME= 'D:\Programming\ITI\Database\Day 10\advWorkSnapshot.ss'
)
as SNAPSHOT of AdventureWorks2012

update Person.Address set City = 'New City' where AddressID = 1

select City
from Person.Address
where AddressID = 1

---6.
-- Transform all functions in day2 to Stored Procedures
create PROCEDURE getMonthNameProc
    @date date
as
select FORMAT(@date, 'MMMM')

getMonthNameProc
'2000-05-03'

-------
create PROCEDURE printValuesProc
    @n1 int,
    @n2 int
as
WHILE @n1<@n2-1
    BEGIN
    set @n1 += 1
    select @n1
END

printValuesProc 1,10

-------
create PROCEDURE getDeptNameProc
    @id int
AS
SELECT S.St_Fname , D.Dept_Name
from Student S inner join Department D on S.Dept_Id = D.Dept_Id
where s.St_Id = @id

getDeptNameProc 1

--------
create PROCEDURE checkNameProc
    @studNo int
AS
DECLARE @fName VARCHAR(30), @lName VARCHAR(30), @message VARCHAR(100)
select @fName = St_Fname, @lName = St_Lname
from Student
where St_Id = @studNo
if @fName is null and @lName is null
        SET @message = 'First name and last name are null'
    else if @fName is NULL
        set @message = 'First name is null'
    else if @lName is NULL
        set @message = 'Last name is null'
    else
        set @message = 'First and last name are not null'
SELECT @message

checkNameProc
1

---------
CREATE PROCEDURE printDeptName_MgrName
    @mgrId INT
AS
select D.Dept_Name, I.Ins_Name, D.Manager_hiredate
from Department D INNER join Instructor I
    on D.Dept_Id = I.Dept_Id
where I.Ins_Id = @mgrId

printDeptName_MgrName 1

--------
alter PROCEDURE printStudentNameProc
    @format varchar(20)
as
DECLARE @t table
           (
    sname varchar(20)
		   )
if @format='first'
			insert into @t
select St_Fname
from Student
		else if @format='last'
			insert into @t
select St_Lname
from Student
		else if @format='fullname'
			insert into @t
select concat(st_fname,'',st_lname)
from Student
select *
from @t

printStudentNameProc 'fullname'

---7.
-- Create full, differential Backup for SD DB.
BACKUP DATABASE SD
to disk = 'D:\Programming\ITI\Database\Day 10\SD_Full.bak'

BACKUP DATABASE SD
to disk = 'D:\Programming\ITI\Database\Day 10\SD_Diff.bak'
with Differential

---8.
-- Use display student’s data (ITI DB) in excel sheet
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;

EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;

INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 
                       'Excel 12.0; Database=D:\Programming\ITI\Database\Day 10\StudentsData.xlsx;', 
                       'SELECT * FROM [Sheet1$]')
SELECT S.St_Id, S.St_Fname, S.St_Lname, S.St_Address,
    S.St_Age, S.Dept_Id, S.St_super
FROM Student S;