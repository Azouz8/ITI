--Lab3
--1
    select D.DeptName , D.Sex
    from
        Dependent D inner join Employee E
        on D.ESSN = E.SSN
    where E.Sex = 'f' and D.Sex= 'f'
union
    select D.DeptName , D.Sex
    from
        Dependent D inner join Employee E
        on D.ESSN = E.SSN
    where E.Sex = 'm' and D.Sex= 'm'

--2
select P.pname, sum(W.Hours) as [Total hours]
from Project p inner join [Work] W
    on P.Pnum = W.Pno
group by P.Pname


--3
select *
from Department D inner join Employee E
    on D.Dnum = E.Dno
where ssn = (select min(ssn)
from Employee)

--4
select D.Dname, max(E.salary) as [Max salary],
    min(E.salary) as [Min Salary],
    avg(E.salary) as [Average Salary]
from Department D inner join Employee E
    on D.Dnum = E.Dno
group by D.Dname

--5
select E.fname +' '+ E.Lname
from Employee E inner join
    Department D on E.SSN = D.MGRSSN
        and E.SSN not in (select ESSN
        from Dependent)

--6
select D.Dname, D.Dnum, count(E.ssn)
from Department D inner join Employee E
    on D.Dnum = E.Dno
group by D.Dname, D.Dnum
having (avg(isnull(salary,0)) > (select avg(isnull(salary,0))
from Employee))

--7
select fname, lname, pname
from
    Employee E inner join [Work] W on E.SSN = W.ESSn
    inner join Project P on W.Pno = P.Pnum
order by E.Dno, Lname, Fname

--8
select Top 2
    isnull(salary,0)
from Employee
order by salary desc

--9
    select fname + ' ' + lname
    from Employee as Fullname
intersect
    select DeptName
    from Dependent

--11
insert into Department
values
    ('DEPT IT', 100, 112233, '1-11-2006')

--12
update Department set MGRSSN = 968574 where Dnum = 100

--13
update Department set MGRSSN = 102672 where MGRSSN = 223344
update Employee set Superssn = 102672 where Superssn = 223344
update [Work] set ESSn = 102672 where ESSn = 223344
delete from Employee where SSN = 223344

--14
update Employee set salary+=0.3*salary
from Employee E inner join [Work] W
    on E.SSN = W.ESSn
    inner join Project P on W.Pno = P.Pnum and P.Pname = 'Al Rabwah'
