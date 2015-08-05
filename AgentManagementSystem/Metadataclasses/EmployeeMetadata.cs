using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class EmployeeMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Employee's name is missing.")]
        [Display(Name="Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee's rank is missing.")]
        public string Rank { get; set; }

         [Required(ErrorMessage = "Ph# is missing.")]
        public string ContactNumber { get; set; }

         [Required(ErrorMessage = "Employee's salary is missing.")]
        [Range(0,int.MaxValue,ErrorMessage="Provide valid salary.")]
        public Nullable<int> Salary { get; set; }

        public string Address { get; set; }

        [Display(Name="Iqama Number")]
        [Required(ErrorMessage = "Provide valid Iqama number.")]
        public string IqmaNumber { get; set; }


        [Display(Name="Salary Type")]
        public string SalaryType { get; set; }
    }
}