using System;
using System.Collections.Generic;
using System.Text;


namespace Lab
{
    /// <summary>
    /// ENUM for Gender Choice
    /// </summary>
    internal enum Gender
    {
        M,
        F
    }
    /// <summary>
    /// ENUM for Security Previliges Choice
    /// </summary>
    internal enum SecurityPrev : byte
    {
        guest,
        developer,
        secretary,
        DBA
    }
    /// <summary>
    /// The Employee Class
    /// </summary>
    internal struct Employee
    {
        int id, salary;
        Gender gender;
        SecurityPrev securityPrev;
        HiringDate hiringDate;
        /// <summary>
        /// Parameterized Constructor of the Employee
        /// </summary>
        public Employee(int id, int salary, Gender gender, SecurityPrev securityPrev, HiringDate hiringDate)
        {
            this.id = id;
            this.salary = salary;
            this.gender = gender;
            this.securityPrev = securityPrev;
            this.hiringDate = hiringDate;
        }
        /// <summary>
        /// The setters of the fields of the employee
        /// </summary>
        public void setID(int id)
        {
            this.id = id;
        }
        public void setSalary(int salary)
        {
            this.salary = salary;
        }
        public void setGender(string gender)
        {
            try
            {
                this.gender = (Gender)Enum.Parse(typeof(Gender), gender, true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Gender must be 'M' or 'F'.", nameof(gender), ex);
            }
        }
        public void setSecPrev(SecurityPrev securityPrev)
        {
            this.securityPrev = securityPrev;
        }
        public void setHiringDate(HiringDate hiringDate)
        {
            this.hiringDate = hiringDate;
        }
        /// <summary>
        /// The getters of the fields of the employee
        /// </summary>
        public int getID()
        {
            return id;
        }

        public int getSalary()
        {
            return salary;
        }

        public string getGender()
        {
            return gender.ToString();
        }

        public string getSecPrev()
        {
            return securityPrev.ToString();
        }

        public String getHiringDate()
        {
            return hiringDate.ToString();
        }
        public override string ToString()
        {
            string message = String.Format("Emp ID: {0}, Salary: {1:C}", id, salary);
            return message;
        }
        /// <summary>
        /// Sorting method for and array of Employee based on their hiring date
        /// </summary>
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