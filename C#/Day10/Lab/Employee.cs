namespace Lab
{
    public class Employee
    {
        public event EventHandler<EmpLayOffEventArgs> EmpLayOff;
        protected virtual void OnEmpLayOff(EmpLayOffEventArgs e)
        {
            EmpLayOff?.Invoke(this, e);
        }
        public int ID { get; set; }
        public DateTime BirthDate
        {
            get;
            set;
        }
        public virtual int VacationStock
        {
            get;
            set;
        }
        public bool RequestVication(DateTime From, DateTime To)
        {
            if (To.Subtract(From).Days > VacationStock)
            {
                OnEmpLayOff(new EmpLayOffEventArgs() { Cause = LayOffCause.VacationStockLimit });
                return false;
            }
            return true;
        }
        public virtual void EndOfYearOperation()
        {
            if (DateTime.Now.Subtract(BirthDate).Days / 365 >= 60)
            {
                OnEmpLayOff(new EmpLayOffEventArgs() { Cause = LayOffCause.Over60Years });
            }
        }
    }
}