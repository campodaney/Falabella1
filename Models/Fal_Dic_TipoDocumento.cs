//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Falabella.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fal_Dic_TipoDocumento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fal_Dic_TipoDocumento()
        {
            this.Fal_Dic_Cliente = new HashSet<Fal_Dic_Cliente>();
        }
    
        public int tid_IdTipoDocumento_PK { get; set; }
        public string tid_Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fal_Dic_Cliente> Fal_Dic_Cliente { get; set; }
    }
}
