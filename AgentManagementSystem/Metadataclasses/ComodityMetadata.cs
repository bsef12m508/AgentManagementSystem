using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AgentManagementSystem.Metadataclasses
{
    public class ComodityMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage="Comodity name is missing.")]
        [Display (Name="Item name ")]
        public string Title { get; set; }
    }
}