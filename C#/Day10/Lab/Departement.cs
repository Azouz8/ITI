namespace Lab
{
    internal class Departement
    {
        public int DeptID { get; set; }
        public required string DeptName { get; set; }
        List<Employee> Staff;
        public Departement()
        {
            Staff = new List<Employee>();
        }
        public int StaffCount => Staff.Count;
        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmpLayOff += RemoveStaff;
        }
        //CallBack
        public void RemoveStaff(object sender, EmpLayOffEventArgs e)
        {
            if (sender is Employee E)
            {
                Staff.Remove(E);
            }
        }
    }
}