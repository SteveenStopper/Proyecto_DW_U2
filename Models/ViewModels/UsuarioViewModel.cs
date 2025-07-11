using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_development_project_U2.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id_usu { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password_usu { get; set; }

        [Required(ErrorMessage = "El campo correo es obligatorio.")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [StringLength(15)]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [StringLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        public int Id_rol { get; set; }
    }
}