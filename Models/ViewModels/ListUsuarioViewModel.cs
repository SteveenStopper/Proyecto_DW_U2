using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_development_project_U2.Models.ViewModels
{
    public class ListUsuarioViewModel
    {
        public int Id_usu { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password_usu { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Id_rol { get; set; }
        public virtual ICollection<ListPrestamoViewModel> Prestamos { get; set; }
    }
}