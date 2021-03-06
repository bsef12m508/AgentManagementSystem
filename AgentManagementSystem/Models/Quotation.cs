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

    [MetadataType(typeof(Metadataclasses.QuotationMetadata))]
    public partial class Quotation
    {
        public Quotation()
        {
            this.ServiceForQuotations = new HashSet<ServiceForQuotation>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ShipperId { get; set; }
        public Nullable<int> ConsigneeId { get; set; }
        public Nullable<int> ComodityId { get; set; }
        public Nullable<int> PackingId { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> LoadingPort { get; set; }
        public Nullable<int> DischargePort { get; set; }
        public string FlightNo { get; set; }
        public Nullable<System.DateTime> SailingDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> PayedAmount { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Comodity Comodity { get; set; }
        public virtual Consignee Consignee { get; set; }
        public virtual Packing Packing { get; set; }
        public virtual Port Port { get; set; }
        public virtual Port Port1 { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<ServiceForQuotation> ServiceForQuotations { get; set; }
    }
}
