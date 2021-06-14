using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    public class PoslovnoPravilo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var kupac = (Kupac)validationContext.ObjectInstance;

            if ((DateTime.Now.Year - kupac.DatumRodjenja.Year) < kupac.Godine)
                return new ValidationResult("Kupac nije punoletan.");
            else
                return ValidationResult.Success;
        }
    }
}
