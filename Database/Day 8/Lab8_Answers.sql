USE ITI

---1.
-- Create a view that displays student full name,
-- course name if the student has a grade more than 50. 
create VIEW vStudent
(
    studName,
    courseName
)
as
    SELECT S.St_Fname, C.Crs_Name
    from Student S INNER JOIN Stud_Course SC on S.St_Id = SC.St_Id
        INNER JOIN Course C on SC.Crs_Id = C.Crs_Id
    Where sc.Grade > 50

SELECT *
from vStudent


---2.
-- Create an Encrypted view that displays manager
-- names and the topics they teach. 
CREATE view managerTopics
(
    managerName,
    topicName
)
with
    encryption
AS
    select I.Ins_Name, T.Top_Name
    from Department D INNER JOIN Instructor I on D.Dept_Manager = I.Ins_Id
        INNER JOIN Ins_Course IC on I.Ins_Id = IC.Ins_Id
        INNER JOIN Course C on C.Crs_Id = IC.Crs_Id
        INNER JOIN Topic T on C.Top_Id = T.Top_Id

SELECT *
from managerTopics


---3.
-- Create a view that will display Instructor Name,
-- Department Name for the ‘SD’ or ‘Java’ Department
Create VIEW InsForSD_Java
(
    InstructorName,
    DeptName
)
AS
    select I.Ins_Name, D.Dept_Name
    from Department D INNER JOIN Instructor I on D.Dept_Id = I.Dept_Id
    where D.Dept_Name = 'SD' or D.Dept_Name = 'Java'

SELECT *
from InsForSD_Java

---4.
-- Create a view “V1” that displays student data for student
-- who lives in Alex or Cairo. 
-- Note: Prevent the users to run the following query 
-- Update V1 set st_address=’tanta’
-- Where st_address=’alex’;
CREATE VIEW V1
(
    sID,
    fName,
    lName,
    address,
    age,
    deptID,
    superID
)
AS
    select S.St_Id, s.St_Fname, s.St_Lname,
        s.St_Address, s.St_Age, s.Dept_Id, s.St_super
    from Student S
    where St_Address = 'alex' or St_Address = 'cairo'
    with check option

select *
from V1

UPDATE V1 set address='tanta'

---5.
-- Create a view that will display the project name and 
-- the number of employees work on it. “Use SD database”
use SD
ALTER view project_empCount
(
    projectName,
    EmpNo
)
AS
    SELECT P.ProjectName, count(*)
    from Company.Project P INNER JOIN Works_on WO on P.ProjectNo = WO.ProjectNO
    GROUP BY P.ProjectName

select *
from project_empCount

---6.
-- Create index on column (Hiredate) that allow u to cluster the
-- data in table Department. What will happen?
CREATE CLUSTERED INDEX hireDateCluster
on Department(Manager_hiredate)
-- This will give an error because there 
-- is a clustered index and it has to 
-- be one clustered index(Dept_id)

---7.
-- Create index that allow u to enter unique ages in student
-- table. What will happen? 
create UNIQUE index uniqueAges
on Student(St_Age)
-- This will give an error because the ages has to 
-- be unique first

---8.
-- Using Merge statement between the following two tables
-- [User ID, Transaction Amount]
MERGE Last_Transaction as tar
using Daily_Transaction as src
on tar.userID = src.userID 
when MATCHED THEN
    UPDATE
        set tar.transAmount = src.transAmount
when not Matched THEN by target THEN
insert
    (userID, transAmout)
values(src.userID, src.transAmout)


----PART 2
use SD

---1.
-- Create view named   “v_clerk” that will display employee#,project#,
-- the date of hiring of all the jobs of the type 'Clerk'
create VIEW v_clerk
(
    empNo,
    projectNo,
    hireDate
)
AS
    select E.EmpNo, WO.ProjectNo, WO.Enter_Date
    from HR.Employee as E INNER JOIN Works_on WO on E.EmpNo = WO.EmpNo
    where WO.Job = 'Clerk'

select *
from v_clerk


---2.
-- Create view named  “v_without_budget” that will display all the
-- projects data without budget
CREATE VIEW v_without_budget
(
    projectNO,
    projectName
)
AS
    select P.ProjectNo, P.ProjectName
    from Company.Project P

select *
from v_without_budget


---3.
-- Create view named  “v_count “ that will display the project
-- name and the # of jobs in it
create VIEW v_count
(
    projectName,
    noOfJobs
)
AS
    select P.ProjectName, COUNT(*)
    from Company.Project P INNER JOIN Works_on WO on P.ProjectNo = WO.ProjectNo
    GROUP BY P.ProjectName

select *
from v_count

---4.
-- Create view named ” v_project_p2” that will display the emp#
-- for the project# ‘p2’ use the previously created view  “v_clerk”
select *
from v_clerk
create view v_project_p2
(
    empNo
)
AS
    SELECT empNo
    from v_clerk
    where projectNo = 2

select *
from v_project_p2

---5.
-- modifey the view named  “v_without_budget”  to display all DATA
-- in project p1 and p2 
ALTER VIEW v_without_budget
(
    projectNO,
    projectName
)
AS
    select P.ProjectNo, P.ProjectName
    from Company.Project P
    where P.ProjectNo = 1 or P.ProjectNo = 2

select *
from v_without_budget

---6.
-- Delete the views  “v_ clerk” and “v_count”
drop view v_count,v_clerk

---7.
-- Create view that will display the emp# and
-- emp lastname who works on dept# is ‘d2’
create view empNo_empLname
(
    empNo,
    lName
)
AS
    SELECT E.EmpNo, E.[Emp Lname]
    from HR.Employee E INNER JOIN Company.Department D
        on E.[Dept No] = D.DeptNo
    where D.DeptNo = 2

select *
from empNo_empLname

---8.
-- Display the employee lastname that contains letter “J”
-- Use the previous view created in Q#7
select *
from empNo_empLname E
where E.lName like '%J%'

---9.
-- Create view named “v_dept” that will display the department#
-- and department name.
create view v_dept
(
    deptNo,
    deptName
)
AS
    select D.DeptNo, D.DeptName
    from Company.Department D

select *
from v_dept

---10.
-- using the previous view try enter new department data where
-- dept# is ’d4’ and dept name is ‘Development’
insert into v_dept
VALUES(4, 'Developement')
-- This will give an error
-- because the Dept_id is 
-- an idetity column and 
-- shouldn't be entered 
-- manually

---11.
-- Create view name “v_2006_check” that will display employee#,
-- the project #where he works and the date of joining the project 
-- which must be from the first of January and the last of December 2006.
create view v_2006_check
(
    empNo,
    projNo,
    joinDate
)
as
    select WO.EmpNo, WO.ProjectNo, WO.Enter_Date
    from HR.Employee E INNER JOIN Works_on WO on E.EmpNo = WO.EmpNo
    where WO.Enter_Date BETWEEN '2006-01-01' and '2006-12-31'

select *
from v_2006_check