using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class PackingMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage="Title is missing.")]
        [Display(Name="Packing Type")]
        public string Title { get; set; }
    }
}