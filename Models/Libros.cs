//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_development_project_U2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Libros()
        {
            this.Prestamos = new HashSet<Prestamos>();
        }
    
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public Nullable<int> anio_publicacion { get; set; }
        public string categoria { get; set; }
        public byte[] imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}
