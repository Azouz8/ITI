use Company_SD

-- Day 2
--1
select * from Employee
--2
select fname,lname,salary,Dno from Employee

select * from Project
--3
select pname,pLocation, dnum from Project
--4
select fullname = fname + ' ' + lname , salary * 12* 0.1 as ANNUAL_COMM from Employee
--5
select ssn , fname, lname from Employee where salary>1000
--6
select ssn , fname, lname from Employee where salary*12>10000
--7
select fname,lname,salary from Employee where sex='f'
--8
select dname,dnum from Departments where MGRSSN = 968574
--9
select pnumber, pname, plocation from Project where dnum=10


-- Day 3
--1
select D.dnum , E.fname , E.ssn
from Departments D inner join Employee E
on D.MGRSSN = E.SSN

--2
select D.dname , P.pname
from Departments D inner join Project P
on D.Dnum = P.Dnum

--3
select D.*, E.Fname+' '+E.Lname as Fullname
from Dependent D inner join Employee E
on D.ESSN = E.SSN

--4
select pname, pnumber, plocation 
from Project where city in('cairo','alex')

--5
select * from Project where pname like 'a%'

--6
select * from Employee where Dno = 30 and salary between 1000 and 2000

--7
select E.fname 
from Employee E inner join Works_for W 
on E.SSN = W.ESSn inner join
Project P on W.Pno = P.pnumber
where E.Dno = 10 and W.Hours >= 10 and P.Pname = 'AL Rabwah'

--8
select X.Fname
from Employee X , Employee Y
where Y.SSN = X.Superssn and Y.Fname = 'Kamel'

--9
select E.fname, P.pname
from Employee E inner join Works_for W on E.SSN = W.ESSn 
inner join Project P on P.Pnumber = W.Pno order by P.Pname

--10
select P.pnumber, D.Dname, E.Lname, E.Bdate, E.Address
from Project P inner join Departments D on P.Dnum = D.Dnum
inner join Employee E on E.SSN = D.MGRSSN 
where P.City = 'Cairo'

--11
select E.*
from Employee E inner join Departments D
on D.MGRSSN = E.SSN

--12
select E.*, D.*
from Employee E left outer join Dependent D
on E.SSN = D.ESSN

--13
insert into Employee values('Ali','Azouz',102672,'2002-08-08','Cairo','M',3000, 112233,30)

--14
insert into Employee(fname,Lname,SSN,Bdate,Address,Sex,Dno) values('Ahmed','Mohamed',102660,'2002-05-18','Cairo','M',30)

--15
update Employee set salary += 0.2*Salary where SSN = 102672