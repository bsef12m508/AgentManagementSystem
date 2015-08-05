using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class ServiceForQuotationMetadata
    {
        [Key]
        public int Id { get; set; }

        public Nullable<int> ServiceId { get; set; }
        [Required (ErrorMessage="Please provide quantity.")]
        [Range(0,int.MaxValue,ErrorMessage="Provide valid quantity.")]
        public Nullable<int> Quantity { get; set; }

        [Required(ErrorMessage = "Please provide unit price.")]
        [Range(0,int.MaxValue,ErrorMessage="Provide valid unit price.")]
        [Display(Name="Unit Price")]
        public Nullable<int> UnitPrice { get; set; }
        public Nullable<int> QuotationId { get; set; }
    }
}