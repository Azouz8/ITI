namespace Lab;

class Program
{
    static void Main(string[] args)
    {
        Departement dept = new Departement { DeptID = 1, DeptName = "IT Department" };
        Club club = new Club { ClubID = 1, ClubName = "Company Club" };

        Employee emp1 = new Employee { ID = 1, BirthDate = DateTime.Now.AddYears(-25), VacationStock = 10 };
        SalesPerson emp2 = new SalesPerson { ID = 2, BirthDate = DateTime.Now.AddYears(-30), AchievedTarget = 50, Target = 100 };
        BoardMember emp3 = new BoardMember { ID = 3, BirthDate = DateTime.Now.AddYears(-50) };
        Employee emp4 = new Employee { ID = 4, BirthDate = DateTime.Now.AddYears(-59), VacationStock = 10 };

        dept.AddStaff(emp1);
        dept.AddStaff(emp2);
        dept.AddStaff(emp3);
        dept.AddStaff(emp4);
        club.AddMember(emp1);
        club.AddMember(emp2);
        club.AddMember(emp3);
        club.AddMember(emp4);

        Console.WriteLine($"Department Staff: {dept.StaffCount}");
        Console.WriteLine($"Club Members: {club.MembersCount}");


        Console.WriteLine("Vacation Case");
        emp1.RequestVication(DateTime.Now, DateTime.Now.AddDays(15));
        Console.WriteLine($"Department Staff after: {dept.StaffCount}");
        Console.WriteLine($"Club Members after: {club.MembersCount}");


        Console.WriteLine("Age Case");
        emp4.BirthDate = DateTime.Now.AddYears(-65);
        emp4.EndOfYearOperation();
        Console.WriteLine($"Department Staff after: {dept.StaffCount}");
        Console.WriteLine($"Club Members after: {club.MembersCount}");


        Console.WriteLine("Target not Achieved Case");
        emp2.EndOfYearOperation();
        Console.WriteLine($"Department Staff after: {dept.StaffCount}");
        Console.WriteLine($"Club Members after: {club.MembersCount}");

        Console.WriteLine("Resign not Achieved Case");
        emp3.Resign();
        Console.WriteLine($"Department Staff after: {dept.StaffCount}");
        Console.WriteLine($"Club Members after: {club.MembersCount}");
    }
}
