namespace Exam2Question2.Models
{
    public enum Rate
    {
        A, B, C, D, F
    }

    public class Billing
    {
        public int BillingID { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public Rate? Rate { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
    }
}