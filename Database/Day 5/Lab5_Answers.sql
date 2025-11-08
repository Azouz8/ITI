--Day 5
--1
use ITI
select count(st_id)
from Student
where St_Age is not null

--2
select distinct Ins_Name
from Instructor

--3
select St_Id , ISNULL(St_Fname,'') +' '+ISNULL(St_lname, '') as [Student Full Name],
	Dept_Name
from Student inner join Department on Student.Dept_Id = Department.Dept_Id

--4
select I.Ins_Name , D.Dept_Name
from Instructor I inner join Department D
	on I.Dept_Id = D.Dept_Id

--5
select S.St_Fname , C.Crs_Name
from Student S inner join Stud_Course SC
	on S.St_Id = SC.St_Id inner join Course C
	on SC.Crs_Id = C.Crs_Id
where SC.Grade is not null

--6
select count(*) as [No. of Courses], T.Top_Name
from Course C inner join Topic T
	on C.Top_Id = T.Top_Id
group by T.Top_Name

--7
select min(I.Salary) as [min salary], max(I.Salary) as [max salary]
from Instructor I

--8
select *
from Instructor I
where I.Salary < (select avg(Salary)
from Instructor)

--9
select D.Dept_Name
from Department D inner join Instructor I
	on D.Dept_Id = I.Dept_Id
where I.Ins_Id = (select top 1
	Ins_Id
from Instructor
order by Salary)

--10
select top(2)
	salary
from Instructor
order by Salary desc

--11
select ins_name , coalesce (convert(varchar(10), Salary), 'bonus')
from Instructor

--12
select avg(salary)
from Instructor

--13
select X.St_Fname, Y.*
from Student X inner join Student Y
	on Y.St_Id = X.St_super

--14
select *
from
	(select salary, ROW_NUMBER() over (partition by dept_id order by salary desc) as RN
	from Instructor I ) as newTable
where RN<=2

--15
select *
from
	(select *, ROW_NUMBER() over (partition by dept_id order by newid()) as RN
	from Student I ) as newTable
where RN=1 and Dept_Id is not null


--Part 2
--1
use AdventureWorks2012
select SalesOrderID , ShipDate
from Sales.SalesOrderHeader
where ShipDate between '7/28/2002' and '7/29/2014'

--2
select ProductID, Name
from Production.Product
where StandardCost < 110

--3
select ProductID, Name
from Production.Product
where Weight is null

--4
select *
from Production.Product
where Color in ('Red', 'Silver', 'Black')

--5
select *
from Production.Product
where Name like 'b%'

--6
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select *
from Production.ProductDescription
where Description like '%[_]%'

--7
select sum(TotalDue)
from Sales.SalesOrderHeader
where ShipDate between '7/1/2001' and '7/31/2014'
group by OrderDate

--8
select distinct Hiredate
from HumanResources.Employee

--9
select avg(distinct ListPrice)
from Production.Product

--10
select 'The '+ Name + ' is only! ', ListPrice
from Production.Product
where ListPrice between 100 and 120

--11
select rowguid, Name, SalesPersonID, Demographics
into storeArchive
from Sales.Store

--12
select Format(GETDATE(), 'dd/MM/yyy')
select Format(GETDATE(), 'yyy-MM-dd')
select Format(GETDATE(), 'MMMM dd, yyyy')
select CONVERT(varchar(10), GETDATE(), 101)
select CONVERT(varchar(10), GETDATE(), 103)
select CONVERT(varchar(10), GETDATE(), 120)