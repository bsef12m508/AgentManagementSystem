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

    [MetadataType(typeof(Metadataclasses.PortMetadata))]
    public partial class Port
    {
        public Port()
        {
            this.Quotations = new HashSet<Quotation>();
            this.Quotations1 = new HashSet<Quotation>();
        }
    
        public int Id { get; set; }
        public string PortName { get; set; }
        public string Country { get; set; }
    
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Quotation> Quotations1 { get; set; }
    }
}