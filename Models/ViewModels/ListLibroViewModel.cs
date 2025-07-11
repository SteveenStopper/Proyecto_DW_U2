using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_development_project_U2.Models.ViewModels
{
    public class ListLibroViewModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public int anio_publicacion { get; set; }
        public string categoria { get; set; }
    }
}