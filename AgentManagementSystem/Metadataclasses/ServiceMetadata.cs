using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{

    public class ServiceMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage="Service code is missing.")]
        [Display (Name="Service Code")]
        public string Code { get; set; }

        [Required (ErrorMessage="Title is missing.")]
        public string Title { get; set; }


        public string Description { get; set; }
    }
}