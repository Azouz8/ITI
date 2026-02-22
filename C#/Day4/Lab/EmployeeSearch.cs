using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab
{
    internal class EmployeeSearch
    {

        Employee[] employees;
        public EmployeeSearch(Employee[] employees)
        {
            this.employees = employees;
        }

        public Employee this[int ID]
        {
            get
            {
                for(int i=0; i<employees.Length; i++)
                {
                    if (employees[i].ID == ID)
                    {
                        return employees[i];
                    }
                }
                return default;
            }
        }

        public Employee[] this[string Name]
        {
            get
            {
                List<Employee> employeesList = new List<Employee>();
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Name == Name)
                    {
                        employeesList.Add(employees[i]);
                    }
                }
                return employeesList.ToArray();
            }
        }
        public Employee[] this[HiringDate hiringDate]
        {
            get
            {
                List<Employee> employeesList = new List<Employee>();
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Hiring.getDay() == hiringDate.getDay() &&
                        employees[i].Hiring.getMonth() == hiringDate.getMonth() &&
                        employees[i].Hiring.getYear() == hiringDate.getYear())
                    {
                        employeesList.Add(employees[i]);
                    }
                }
                return employeesList.ToArray();
            }
        }

    }
}
