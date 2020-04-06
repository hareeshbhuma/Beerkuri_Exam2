using System;
using System.Collections.Generic;

namespace Exam2Question2.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime BillingDate { get; set; }

        public virtual ICollection<Billing> Billings { get; set; }
    }
}