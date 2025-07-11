using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_development_project_U2.Models.ViewModels
{
    public class ListPrestamoViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public virtual ListUsuarioViewModel Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string TituloLibro { get; set; }
    }
}