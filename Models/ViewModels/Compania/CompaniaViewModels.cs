using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Compania
{
    public class CompaniaViewModels
    {       
        public int idCompania { get; set; }
        public int idUsuario { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Persona Contacto")]
        public string personaContacto { get; set; }
        [Display(Name = "Telefono")]
        public string telefonoContacto { get; set; }
        [Display(Name = "Nit")]
        public string nit { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaRegistro { get; set; }

       
    }
}