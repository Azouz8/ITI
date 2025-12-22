use ITI

--- 1.
create function getMonthName(@date date)
RETURNS VARCHAR(20)
begin
    return FORMAT(@date, 'MMMM')
end

select dbo.getMonthName(GETDATE())

--- 2.
ALTER FUNCTION printValues(@n1 int , @n2 int)
RETURNS @t
TABLE
(num int)
AS
BEGIN
    WHILE @n1 < @n2-1
        BEGIN
        SET @n1+=1
        INSERT into @t
        VALUES(@n1)
    END
    RETURN
END

SELECT *
from printValues(1,10)

--- 3.
ALTER FUNCTION getDeptName(@studNo int)
returns TABLE
AS  
RETURN(
    SELECT S.St_Fname , D.Dept_Name
from Student S inner join Department D on S.Dept_Id = D.Dept_Id
where s.St_Id = @studNo
)

select *
from getDeptName(2)

--- 4.
CREATE FUNCTION checkName(@studNo int) RETURNS VARCHAR(30)
BEGIN
    DECLARE @fName VARCHAR(30)
    DECLARE @lName VARCHAR(30)
    DECLARE @message VARCHAR(100)
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
    RETURN @message
END

select dbo.checkName(1)

--- 5.
CREATE FUNCTION printDeptName_ManagerName(@managerID int)
RETURNS table
as
RETURN
(
select D.Dept_Name, I.Ins_Name, D.Manager_hiredate
from Department D INNER join Instructor I
    on D.Dept_Id = I.Dept_Id
where I.Ins_Id = @managerID
)

select *
from printDeptName_ManagerName(1)

--- 6.
create function printStudentName(@format varchar(20))
returns @t table
           (
    sname varchar(20)
		   )
as
	begin
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
    return
end

select *
from printStudentName('fullname')


--- 7.
select St_Id, SUBSTRING(St_Fname,1,len(St_Fname)-1 )
from Student

--- 8.
UPDATE SC SET SC.Grade = null
FROM Stud_Course SC INNER JOIN Student S
    on SC.St_Id = S.St_Id INNER JOIN
    Department D on S.Dept_Id = D.Dept_Id
    where D.Dept_Name = 'SD'