using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_development_project_U2.Filters
{
    public class FechaDevolucionValidaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime fechaDevolucion)
            {
                DateTime fechaActual = DateTime.Now;

                if (fechaDevolucion <= fechaActual)
                {
                    return new ValidationResult("La fecha de devolución debe ser mayor a la fecha actual.");
                }
            }

            return ValidationResult.Success;
        }
    }

}