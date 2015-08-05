using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class PortMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage="Port name is missing.")]
        [Display (Name="Port Name")]
        public string PortName { get; set; }

        [Required (ErrorMessage="Country name is missing.")]
        [Display (Name="Country ")]
        public string Country { get; set; }
    }
}