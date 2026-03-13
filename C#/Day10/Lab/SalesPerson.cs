namespace Lab
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public int Target { get; set; }
        public override int VacationStock
        {
            get => int.MaxValue;
            set { }
        }
        public bool CheckTarget(int Quota)
        {
            return AchievedTarget >= Quota;
        }
        public override void EndOfYearOperation()
        {
            if (!CheckTarget(Target))
            {
                OnEmpLayOff(new EmpLayOffEventArgs() { Cause = LayOffCause.TargetNotAchieved });
            }
        }
    }
}