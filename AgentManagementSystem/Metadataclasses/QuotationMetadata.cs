using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class QuotationMetadata
    {
        [Key]
        public int Id { get; set; }
        
        public Nullable<System.DateTime> Date { get; set; }

        [Display(Name="Shipper")]
        public Nullable<int> ShipperId { get; set; }
        [Display(Name="Consignee")]
        public Nullable<int> ConsigneeId { get; set; }
        [Display(Name="Comodity")]
        public Nullable<int> ComodityId { get; set; }
        [Display(Name = "Packing")]
        public Nullable<int> PackingId { get; set; }

        [Required (ErrorMessage="Provide valid weight.")]
        public Nullable<double> Weight { get; set; }
        [Display(Name = "Loading Port")]
        public Nullable<int> LoadingPort { get; set; }
        [Display(Name = "Discharge Port")]
        public Nullable<int> DischargePort { get; set; }
        [Display(Name = "Flight #")]
        [Required(ErrorMessage = "Provide valid flight #.")]
        public string FlightNo { get; set; }
        [Display(Name = "Sailing Date")]
        [Required(ErrorMessage = "Provide valid sailing date.")]
        public Nullable<System.DateTime> SailingDate { get; set; }
        [Display(Name = "Arrival Date")]
        [Required(ErrorMessage = "Provide valid arrival date.")]
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string Status { get; set; }
        [Display(Name = "Paid Amount")]
        public Nullable<int> PayedAmount { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Provide valid quantity.")]
        public Nullable<int> Quantity { get; set; }
    }
}