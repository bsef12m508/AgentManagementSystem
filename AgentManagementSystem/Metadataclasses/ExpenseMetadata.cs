using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class ExpenseMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage="Title is missing.")]
        public string Title { get; set; }

        [Required (ErrorMessage="Amount is missing.")]
        [Range(0,int.MaxValue,ErrorMessage="Provide valid amount.")]
        public Nullable<int> Amount { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public string Description { get; set; }
    }
}