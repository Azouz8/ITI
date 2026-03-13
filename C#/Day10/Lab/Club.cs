namespace Lab
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members;
        public Club()
        {
            Members = new List<Employee>();
        }
        public int MembersCount => Members.Count;

        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmpLayOff += RemoveMember;
        }

        ///CallBackMethod 
        public void RemoveMember(object sender, EmpLayOffEventArgs e)
        {
            if (sender is Employee E && E is not BoardMember)
            {
                Members.Remove(E);
            }
        }
    }

}