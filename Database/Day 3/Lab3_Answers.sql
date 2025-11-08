--1
select D.dnum , E.fname , E.ssn
from Department D inner join Employee E
    on D.MGRSSN = E.SSN

--2
select D.dname , P.pname
from Department D inner join Project P
    on D.Dnum = P.Dnum

--3
select D.*, E.Fname+' '+E.Lname as Fullname
from Dependent D inner join Employee E
    on D.ESSN = E.SSN

--4
select pname, Pnum, plocation
from Project
where PLocation in('cairo','alex')

--5
select *
from Project
where pname like 'a%'

--6
select *
from Employee
where Dno = 30 and salary between 1000 and 2000

--7
select E.fname
from Employee E inner join [Work] W
    on E.SSN = W.ESSn inner join
    Project P on W.Pno = P.Pnum
where E.Dno = 10 and W.Hours >= 10 and P.Pname = 'AL Rabwah'

--8
select X.Fname
from Employee X , Employee Y
where Y.SSN = X.Superssn and Y.Fname = 'Kamel'

--9
select E.fname, P.pname
from Employee E inner join [Work] W on E.SSN = W.ESSn
    inner join Project P on P.Pnum = W.Pno
order by P.Pname

--10
select P.Pnum, D.Dname, E.Lname, E.Bdate, E.Address
from Project P inner join Department D on P.Dnum = D.Dnum
    inner join Employee E on E.SSN = D.MGRSSN
where P.PLocation = 'Cairo'

--11
select E.*
from Employee E inner join Department D
    on D.MGRSSN = E.SSN

--12
select E.*, D.*
from Employee E left outer join Dependent D
    on E.SSN = D.ESSN

--13
insert into Employee
values('Ali', 'Azouz', 102672, '2002-08-08', 'Cairo', 'M', 3000, 112233, 30)

--14
insert into Employee
    (fname,Lname,SSN,Bdate,Address,Sex,Dno)
values('Ahmed', 'Mohamed', 102660, '2002-05-18', 'Cairo', 'M', 30)

--15
update Employee set salary += 0.2*Salary where SSN = 102672