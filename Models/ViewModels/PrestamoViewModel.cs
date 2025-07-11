using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Web_development_project_U2.Filters;

namespace Web_development_project_U2.Models.ViewModels
{
    public class PrestamoViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        [Display(Name = "Libro")]
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        [Required(ErrorMessage = "La fecha de devolución es requerida.")]
        [FechaDevolucionValida(ErrorMessage = "La fecha de devolución debe ser mayor a la fecha actual.")]
        [Display(Name = "Fecha de devolucion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucion { get; set; }
    }
}