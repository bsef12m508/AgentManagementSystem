//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgentManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(Metadataclasses.ConsigneeMetadata))]
    public partial class Consignee
    {
        public Consignee()
        {
            this.Quotations = new HashSet<Quotation>();
        }
    
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string CompanyName { get; set; }
        public string Addresss { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
        public string POBox { get; set; }
    
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
