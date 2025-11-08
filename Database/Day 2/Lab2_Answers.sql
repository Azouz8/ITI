use Company_SD

-- Day 2
--1
select *
from Employee

--2
select fname, lname, salary, Dno
from Employee

select *
from Project

--3
select pname, pLocation, dnum
from Project

--4
select fullname = fname + ' ' + lname , salary * 12* 0.1 as ANNUAL_COMM
from Employee

--5
select ssn , fname, lname
from Employee
where salary>1000

--6
select ssn , fname, lname
from Employee
where salary*12>10000

--7
select fname, lname, salary
from Employee
where sex='f'

--8
select dname, dnum
from Departments
where MGRSSN = 968574

--9
select pnumber, pname, plocation
from Project
where dnum=10