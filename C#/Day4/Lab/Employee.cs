using System;
using System.Collections.Generic;
using System.Text;


namespace Lab
{
    internal enum Gender
    {
        M,
        F
    }
    internal enum SecurityPrev : byte
    {
        guest,
        developer,
        secretary,
        DBA
    }
    internal struct Employee
    {
        int id, salary;
        string name;
        Gender gender;
        SecurityPrev securityPrev;
        HiringDate hiringDate;

        public Employee(int id,string name, int salary, Gender gender, SecurityPrev securityPrev, HiringDate hiringDate)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.gender = gender;
            this.securityPrev = securityPrev;
            this.hiringDate = hiringDate;
        }
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }
        public SecurityPrev SecurityPrev
        {
            get
            {
                return securityPrev;
            }
            set
            {
                this.securityPrev = value;

            }
        }
        public HiringDate Hiring
        {
            get
            {
                return hiringDate;
            }
            set
            {
                hiringDate = value;
            }
        }

        public override string ToString()
        {
            string message = String.Format("Emp ID: {0}, Salary: {1:C}", id, salary);
            return message;
        }
        public static void SortEmp(ref Employee[] emp)
        {
            for (int i = 0; i < emp.Length; i++)
            {
                for (int j = i + 1; j < emp.Length; j++)
                {
                    if (emp[i].hiringDate.getYear() == emp[j].hiringDate.getYear())
                    {
                        if (emp[i].hiringDate.getMonth() == emp[j].hiringDate.getMonth())
                        {
                            if (emp[i].hiringDate.getDay() > emp[j].hiringDate.getDay())
                            {
                                Employee tempEmp;
                                tempEmp = emp[i];
                                emp[i] = emp[j];
                                emp[j] = tempEmp;
                            }
                        }
                        else if (emp[i].hiringDate.getMonth() > emp[j].hiringDate.getMonth())
                        {
                            Employee tempEmp;
                            tempEmp = emp[i];
                            emp[i] = emp[j];
                            emp[j] = tempEmp;
                        }
                    }
                    else if (emp[i].hiringDate.getYear() > emp[j].hiringDate.getYear())
                    {
                        Employee tempEmp;
                        tempEmp = emp[i];
                        emp[i] = emp[j];
                        emp[j] = tempEmp;
                    }
                }

            }
        }
    }
}