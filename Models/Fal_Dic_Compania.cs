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
    
    public partial class Fal_Dic_Compania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fal_Dic_Compania()
        {
            this.Fal_Tra_CompaniaProducto = new HashSet<Fal_Tra_CompaniaProducto>();
        }
    
        public int com_IdCompania_PK { get; set; }
        public int com_IdUsuario_FK { get; set; }
        public string com_Nombre { get; set; }
        public string com_PersonaContacto { get; set; }
        public string com_TelefonoContacto { get; set; }
        public string com_Nit { get; set; }
        public System.DateTime com_FechaRegistro { get; set; }
    
        public virtual Fal_Dic_Usuario Fal_Dic_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fal_Tra_CompaniaProducto> Fal_Tra_CompaniaProducto { get; set; }
    }
}
