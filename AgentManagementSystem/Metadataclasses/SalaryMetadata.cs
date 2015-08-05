using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class SalaryMetadata
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name="Amount Paid")]
        public Nullable<double> PaidAmount { get; set; }
    }
}