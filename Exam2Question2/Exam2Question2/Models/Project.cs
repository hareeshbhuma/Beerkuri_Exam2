using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam2Question2.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Billing> Billing { get; set; }
    }
}