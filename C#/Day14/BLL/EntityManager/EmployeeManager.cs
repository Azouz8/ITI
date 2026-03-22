using BLL.Entities;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Text;

namespace BLL.EntityManager
{
    public static class EmployeeManager
    {
        static DBManager Manager = new();

        public static bool UpdateJobID(string empID, short JobID)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["@emp_id"] = empID,
                    ["@job_id"] = JobID
                };
                return Manager.ExecuteNonQuery("UpdateEmployeeJob", Parameters) > 0;
            }
            catch (Exception ex)
            {
                // THIS WILL SHOW YOU THE ACTUAL SQL ERROR IN THE OUTPUT WINDOW
                System.Diagnostics.Debug.WriteLine($"SQL Error: {ex.Message}");
                throw; // Temporarily re-throw to see the crash details
            }
            return false;

        }
        public static EmployeeList GetAllEmloyees()
        {
            try
            {
                return DataTableToEmpList(Manager.ExecuteDataTable("GetAllEmployees"));
            }
            catch { }
            return new();
        }

        public static EmployeeList DataTableToEmpList(DataTable dataTable)
        {
            EmployeeList employees = new EmployeeList();
            try
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    employees.Add(DataRowToEmployee(item));
                }
            }
            catch { }
            return employees;
        }

        internal static Employee DataRowToEmployee(DataRow dataRow)
        {
            Employee employee;

            string emp_id = dataRow.Field<string>("emp_id");

            string fname = dataRow.Field<string>("fname");

            string minit = dataRow.Field<string?>("minit");

            string lname = dataRow.Field<string>("lname");

            short job_id = dataRow.Field<short>("job_id");

            Byte? job_lvl = dataRow.Field<Byte?>("job_lvl");

            string pub_id = dataRow.Field<string>("pub_id");

            DateTime hire_date = dataRow.Field<DateTime>("hire_date");

            employee = new Employee
            {
                Emp_id = emp_id,
                Fname = fname,
                Minit = minit,
                Lname = lname,
                Job_id = job_id,
                Job_lvl = job_lvl,
                Pub_id = pub_id,
                Hire_date = hire_date
            };

            return employee;
        }

        internal static DataRow EmployeeToDataRow(DataTable dataTable, Employee employee)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["emp_id"] = employee.Emp_id;
            dataRow["fname"] = employee.Fname;
            dataRow["minit"] = employee.Minit;
            dataRow["lname"] = employee.Lname;
            dataRow["job_id"] = employee.Job_id;
            dataRow["job_lvl"] = employee.Job_lvl;
            dataRow["pub_id"] = employee.Pub_id;
            dataRow["hire_date"] = employee.Hire_date;
            return dataRow;
        }

        internal static DataTable EmloyeeListToDataTable(EmployeeList employees)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("emp_id", typeof(string));
            dataTable.Columns.Add("fname", typeof(string));
            dataTable.Columns.Add("minit", typeof(string));
            dataTable.Columns.Add("lname", typeof(string));
            dataTable.Columns.Add("job_id", typeof(short));
            dataTable.Columns.Add("job_lvl", typeof(Byte));
            dataTable.Columns.Add("pub_id", typeof(string));
            dataTable.Columns.Add("hire_date", typeof(DateTime));
            foreach (Employee employee in employees)
            {
                DataRow dataRow = EmployeeToDataRow(dataTable, employee);
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        public static DataTable GetAllEmployeesDataTable()
        {
            DataTable dt = Manager.ExecuteDataTable("GetAllEmployees");

            dt.PrimaryKey = new DataColumn[] { dt.Columns["emp_id"] };

            return dt;
        }
        public static void SaveChanges(DataTable employees)
        {
            Manager.SaveChanges(employees);
        }
    }
}
