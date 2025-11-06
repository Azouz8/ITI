--Lab3
--1
select D.Dependent_name , D.Sex from
Dependent D inner join Employee E
on D.ESSN = E.SSN
where E.Sex = 'f' and D.Sex= 'f'
union 
select D.Dependent_name , D.Sex from
Dependent D inner join Employee E
on D.ESSN = E.SSN
where E.Sex = 'm' and D.Sex= 'm'

--2
select P.pname,sum(W.hours) as [Total hours]
from Project p inner join Works_for W
on P.Pnumber = W.Pno 
group by P.Pname


--3
select * from Departments D inner join Employee E
on D.Dnum = E.Dno 
where ssn = (select min(ssn) from Employee)

--4
select D.Dname, max(E.salary) as [Max salary],
min(E.salary) as [Min Salary],
avg(E.salary) as [Average Salary]
from Departments D inner join Employee E
on D.Dnum = E.Dno
group by D.Dname

--5
select E.fname +' '+ E.Lname from Employee E inner join 
Departments D on E.SSN = D.MGRSSN 
and E.SSN not in (select ESSN from Dependent)

--6
select D.Dname, D.Dnum, count(E.ssn)
from Departments D inner join Employee E
on D.Dnum = E.Dno
group by D.Dname, D.Dnum
having (avg(isnull(salary,0)) > (select avg(isnull(salary,0)) from Employee))

--7///////work table
select fname, lname, pname from
Employee E inner join Works_for W on E.SSN = W.ESSn 
inner join Project P on W.Pno = P.Pnumber
order by E.Dno, Lname, Fname

--8
select Top 2 isnull(salary,0) from Employee 
order by salary desc

--9
select fname + ' ' + lname from Employee as Fullname
intersect 
select Dependent_name from Dependent

--11
insert into Departments values ('DEPT IT', 100, 112233, '1-11-2006')

--12
update Departments set MGRSSN = 968574 where Dnum = 100

--13
update Departments set MGRSSN = 102672 where MGRSSN = 223344
update Employee set Superssn = 102672 where Superssn = 223344
update Works_for set ESSn = 102672 where ESSn = 223344
delete from Employee where SSN = 223344

--14
update Employee set salary+=0.3*salary
from Employee E inner join Works_for W
on E.SSN = W.ESSn
inner join Project P on W.Pno = P.Pnumber and P.Pname = 'Al Rabwah'
