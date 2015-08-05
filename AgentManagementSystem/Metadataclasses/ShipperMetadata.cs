using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgentManagementSystem.Metadataclasses
{
    public class ShipperMetadata
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Person name(Optional)")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Please mention company name.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please mention complete address.")]
        public string Addresss { get; set; }

        [Display(Name = "Contact number")]
        [Required(ErrorMessage = "Contact number is missing.")]
        public string ContactNumber { get; set; }

        [Display(Name = "Alternative ph# ")]
        public string ContactNumber2 { get; set; }


        [Required(ErrorMessage = "Email is missing.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please mention pobox number.")]
        [Display(Name = "PoBox #")]
        public string POBox { get; set; }
    }
}