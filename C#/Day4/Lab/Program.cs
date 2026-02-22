using Lab;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[3];
            for (int i = 0; i < 3; i++)
            {
                string input;
                int id;
                while (true)
                {
                    Console.WriteLine($"Enter Id for Emp No. {i + 1}");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out id))
                        break;

                    Console.WriteLine("Invalid input! Please enter Numeric Value.");
                }
                Console.WriteLine($"Enter Name for Emp No. {i + 1}");
                string name = Console.ReadLine();

                int salary;
                while (true)
                {
                    Console.WriteLine($"Enter Salary for Emp No. {i + 1}");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out salary))
                        break;

                    Console.WriteLine("Invalid input! Please enter Numeric Value.");
                }

                Gender gender;
                while (true)
                {
                    Console.WriteLine($"Enter Gender (M/F) for Emp No. {i + 1}");
                    string genderIn = Console.ReadLine();

                    if (Enum.TryParse(genderIn, true, out gender))
                        break;

                    Console.WriteLine("Invalid input! Please enter M or F.");
                }
                SecurityPrev securityPrev;
                while (true)
                {
                    Console.WriteLine($"Enter Security Level(guest, developer, secretary, DBA) for Emp No. {i + 1}");
                    string secLevel = Console.ReadLine();
                    if (Enum.TryParse(secLevel, true, out securityPrev))
                        break;
                    Console.WriteLine("Invalid input! Please enter Correct Security Level.");
                }
                DateTime date;
                while (true)
                {
                    Console.WriteLine($"Enter Hiring Date(2025/01/01) for Emp No. {i + 1}");
                    string hiringDate = Console.ReadLine();
                    if (DateTime.TryParse(hiringDate, out date))
                        break;
                    Console.WriteLine("Invalid input! Please enter Date in the correct format.");
                }
                employees[i] = new Employee(id, name, salary, gender, securityPrev, new HiringDate(date.Day, date.Month, date.Year));

            }

            Employee.SortEmp(ref employees);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"ID: {employees[i].ID}");
                Console.WriteLine($"ID: {employees[i].Name}");
                Console.WriteLine($"Salary: {employees[i].Salary}");
                Console.WriteLine($"Gender: {employees[i].Gender}");
                Console.WriteLine($"Sec Level: {employees[i].SecurityPrev}");
                Console.WriteLine($"Hire Date: {employees[i].Hiring}");
            }
            Console.WriteLine("-------------------------------");

            EmployeeSearch empSearch = new EmployeeSearch(employees);
            Employee emp = empSearch[1];
            Console.WriteLine("-------- Search by ID ----------");

            Console.WriteLine(emp);

            Employee[] empSearchListByName = empSearch["Azouz"];
            Console.WriteLine("-------- Search by Name ----------");

            foreach (var e in empSearchListByName)
            {
                Console.WriteLine(e);
            }

            Employee[] empSearchListByDate = empSearch[new HiringDate(1, 1, 2022)];
            Console.WriteLine("-------- Search by Hiring Date ----------");

            foreach (var e in empSearchListByDate)
            {
                Console.WriteLine(e);
            }
        }
    }
}