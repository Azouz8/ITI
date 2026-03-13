namespace Lab
{
    internal class BoardMember : Employee
    {
        public override int VacationStock
        {
            get => int.MaxValue;
            set { }
        }
        public override void EndOfYearOperation() { }
        public void Resign()
        {
            OnEmpLayOff(new EmpLayOffEventArgs() { Cause = LayOffCause.Resignation });
        }
    }
}