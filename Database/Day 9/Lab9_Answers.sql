---1.
-- Create a stored procedure without parameters to show the number
-- of students per department name. 
CREATE PROCEDURE getStudNo
AS
SELECT D.Dept_Name, COUNT(*) as noOfStudents
from Student S INNER JOIN Department D on S.Dept_Id = D.Dept_Id
GROUP BY D.Dept_Name

getStudNo

---2.
-- Create a stored procedure that will check for the # of employees
-- in the project p1 if they are more than 3 print message to the user
-- “'The number of employees in the project p1 is 3 or more'” if they
-- are less display a message to the user “'The following employees work for
-- the project p1'” in addition to the first name and last name of each one. 
CREATE PROCEDURE checkNoOfEmp
AS
declare @x int
select @x = COUNT(*)
from Works_on
where ProjectNo = 1
GROUP BY ProjectNo

if( @x >= 3)
    select 'The number of employees in the project p1 is 3 or more'
else
BEGIN
    select 'The following employees work for the project p1'
    select E.[Emp Fname] , E.[Emp Lname]
    from Works_on WO INNER JOIN HR.Employee E on WO.EmpNo = E.EmpNo
    WHERE ProjectNo = 1
END

checkNoOfEmp


---3.
-- Create a stored procedure that will be used in case there is an old
-- employee has left the project and a new one become instead of him. The
-- procedure should take 3 parameters (old Emp. number, new Emp. number and
-- the project number) and it will be used to update works_on table.
CREATE PROCEDURE updateWorksOn
    @oldEmp int,
    @newEmp int,
    @projNo int
AS
UPDATE Works_on WO
set @oldEmp = @newEmp
where ProjectNo = @projNo

---4.
-- Create an Audit table with the following structure 
CREATE Table AuditHistory
(
    projectNo int,
    userName VARCHAR(20),
    modifiedDate DATE,
    budgetOld INT,
    budgetNew INT
)
-- Create BudgetTracket Trigger to Update Audit History when
-- any update happens to the budget in project table
CREATE TRIGGER budgetTracker
on Company.Project
for update
AS 
if update(budget)
BEGIN
    insert into AuditHistory
    select
        I.ProjectNo, SUSER_NAME() , GETDATE(),
        D.Budget, I.Budget
    from inserted I INNER JOIN deleted D on I.ProjectNo = D.ProjectNo
END

UPDATE Company.Project set Budget = 10000 WHERE ProjectNo = 1


---5.
-- Create a trigger to prevent anyone from inserting a new record in
-- the Department table [ITI DB]
CREATE TRIGGER preventInsertingInDepartement
on Department
for insert
AS
    select 'Sorry! U cant Insert any records in this table'

insert into Department
    (Dept_Id, Dept_Name)
values(340, 'DEV')

---6.
-- Create a trigger that prevents the insertion Process for Employee
-- table in March [Company DB].
CREATE TRIGGER preventInsertEmpOnMarch
on HR.Employee
for insert
AS
    if(FORMAT(GETDATE(),'MMMM') = 'March')
        SELECT 'Sorry! U cant Insert any records in this tabel on MARCH'
    else
        insert into HR.Employee
select *
from inserted


---7.
-- Create a trigger on student table after insert to add Row in Student
-- Audit table (Server User Name , Date, Note) where note will be “[username]
-- Insert New Row with Key=[Key Value] in table [table name]”

CREATE TABLE StudentAudit
(
    serverUserName VARCHAR(20),
    insertDate date,
    note VARCHAR(100)
)

create TRIGGER studentAddingTracker
on Student
after insert
AS
    insert into StudentAudit
select SUSER_NAME(), GETDATE(),
    SUSER_NAME() +' Inserted New Row With Key = '+CAST(inserted.St_Id as varchar)+' in table Student'
from inserted

INSERT into Student
    (St_Id,St_Fname)
VALUES(333, 'AZOUZ')


---8.
-- Create a trigger on student table instead of delete to add Row in
-- Student Audit table (Server User Name, Date, Note) where note will be“
-- try to delete Row with Key=[Key Value]”
alter TRIGGER deletePreventionStudent
on Student
INSTEAD of DELETE
AS
    insert into StudentAudit
select SUSER_NAME(), GETDATE(),
    SUSER_NAME() +' Tried to delete a row with KEY '+CAST(deleted.St_Id as varchar)
from deleted

delete from Student where St_Id = 1